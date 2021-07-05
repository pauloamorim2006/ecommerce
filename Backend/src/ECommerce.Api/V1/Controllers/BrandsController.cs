using AutoMapper;
using ECommerce.Api.Controllers;
using ECommerce.Application.DTO;
using ECommerce.Core.Notifications;
using ECommerce.Domain.Filter;
using ECommerce.Domain.Models;
using ECommerce.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/brands")]
    public class BrandsController : MainController
    {
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;

        public BrandsController(IMapper mapper,
                                      IBrandService brandService,
                                      INotifier notifier) : base(notifier)
        {
            _mapper = mapper;
            _brandService = brandService;
        }


        [HttpGet("subcategory/{subcategoryId:guid}")]
        public async Task<IEnumerable<BrandResponseDTO>> FindBySubcategory(Guid subcategoryId)
        {
            return _mapper.Map<IEnumerable<BrandResponseDTO>>(await _brandService.Find(subcategoryId));
        }

        [HttpPost]
        public async Task<ActionResult<BrandResponseDTO>> Add(BrandAddRequestDTO brandDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            
            await _brandService.Add(_mapper.Map<Brand>(brandDTO));

            return CustomResponse(brandDTO);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<BrandResponseDTO>> Update(Guid id, BrandUpdateRequestDTO brandDTO)
        {
            if (id != brandDTO.Id)
            {
                NotificateError("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(brandDTO);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);           

            await _brandService.Update(_mapper.Map<Brand>(brandDTO));

            return CustomResponse(brandDTO);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<BrandResponseDTO>> Remove(Guid id)
        {
            var brandDTO = await Find(id);

            if (brandDTO == null) return NotFound();

            await _brandService.Remove(id);

            return CustomResponse(brandDTO);
        }        

        private async Task<BrandResponseDTO> Find(Guid id)
        {
            return _mapper.Map<BrandResponseDTO>(await _brandService.FindById(id));
        }
        
    }
}
