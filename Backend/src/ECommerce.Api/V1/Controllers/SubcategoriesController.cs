using AutoMapper;
using ECommerce.Api.Controllers;
using ECommerce.Application.DTO;
using ECommerce.Domain.Models;
using ECommerce.Domain.Services;
using ECommerce.Core.Notifications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/subcategories")]
    public class SubcategoriesController : MainController
    {
        private readonly ISubcategoryService _subcategoryService;
        private readonly IMapper _mapper;

        public SubcategoriesController(IMapper mapper,
                                      ISubcategoryService subcategoryService,
                                      INotifier notifier) : base(notifier)
        {
            _mapper = mapper;
            _subcategoryService = subcategoryService;
        }

        [HttpGet]
        public async Task<IEnumerable<SubcategoryResponseDTO>> FindAll()
        {
            return _mapper.Map<IEnumerable<SubcategoryResponseDTO>>(await _subcategoryService.FindAll());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<SubcategoryResponseDTO>> FindById(Guid id)
        {
            var register = await Find(id);

            if (register == null) return NotFound();

            return register;
        }

        [HttpPost]
        public async Task<ActionResult<SubcategoryResponseDTO>> Add(SubcategoryAddRequestDTO subcategoryDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            
            await _subcategoryService.Add(_mapper.Map<Subcategory>(subcategoryDTO));

            return CustomResponse(subcategoryDTO);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<SubcategoryResponseDTO>> Update(Guid id, SubcategoryUpdateRequestDTO subcategoryDTO)
        {
            if (id != subcategoryDTO.Id)
            {
                NotificateError("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(subcategoryDTO);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);            

            await _subcategoryService.Update(_mapper.Map<Subcategory>(subcategoryDTO));

            return CustomResponse(subcategoryDTO);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<SubcategoryResponseDTO>> Remove(Guid id)
        {
            var registerDTO = await Find(id);

            if (registerDTO == null) return NotFound();

            await _subcategoryService.Remove(id);

            return CustomResponse(registerDTO);
        }

        private async Task<SubcategoryResponseDTO> Find(Guid id)
        {
            return _mapper.Map<SubcategoryResponseDTO>(await _subcategoryService.FindById(id));
        }
        
    }
}
