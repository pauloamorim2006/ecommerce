using AutoMapper;
using ECommerce.Api.Controllers;
using ECommerce.Application.DTO;
using ECommerce.Domain.Models;
using ECommerce.Core.Notifications;
using ECommerce.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ECommerce.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/categories")]
    public class CategoriesController : MainController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(IMapper mapper,
                                      ICategoryService cidadeService,
                                      INotifier notifier) : base(notifier)
        {
            _mapper = mapper;
            _categoryService = cidadeService;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryResponseDTO>> FindAll()
        {
            return _mapper.Map<IEnumerable<CategoryResponseDTO>>(await _categoryService.FindAll());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CategoryResponseDTO>> FindById(Guid id)
        {
            var register = await Find(id);

            if (register == null) return NotFound();

            return register;
        }

        [HttpPost]
        public async Task<ActionResult<CategoryResponseDTO>> Add(CategoryAddRequestDTO categoryDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (categoryDTO.Image != null)
            {
                var imageName = Guid.NewGuid() + "_" + categoryDTO.Image;
                if (!FileUpload(categoryDTO.ImageUpload, imageName))
                {
                    return CustomResponse(categoryDTO);
                }

                categoryDTO.Image = imageName;
            }
            
            await _categoryService.Add(_mapper.Map<Category>(categoryDTO));

            return CustomResponse(categoryDTO);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<CategoryResponseDTO>> Update(Guid id, CategoryUpdateRequestDTO categoryDTO)
        {
            if (id != categoryDTO.Id)
            {
                NotificateError("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(categoryDTO);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (categoryDTO.Image != null)
            {
                var imageNome = Guid.NewGuid() + "_" + categoryDTO.Image;
                if (!FileUpload(categoryDTO.ImageUpload, imageNome))
                {
                    return CustomResponse(ModelState);
                }

                categoryDTO.Image = imageNome;
            }

            await _categoryService.Update(_mapper.Map<Category>(categoryDTO));

            return CustomResponse(categoryDTO);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<CategoryResponseDTO>> Remove(Guid id)
        {
            var categoryDTO = await Find(id);

            if (categoryDTO == null) return NotFound();

            await _categoryService.Remove(id);

            return CustomResponse(categoryDTO);
        }

        private async Task<CategoryResponseDTO> Find(Guid id)
        {
            return _mapper.Map<CategoryResponseDTO>(await _categoryService.FindById(id));
        }

        private bool FileUpload(string file, string imageName)
        {
            if (string.IsNullOrEmpty(file))
            {
                NotificateError("Forneça uma imagem para este produto!");
                return false;
            }

            var imageDataByteArray = Convert.FromBase64String(file);

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imageName);

            if (System.IO.File.Exists(filePath))
            {
                NotificateError("Já existe um arquivo com este nome!");
                return false;
            }

            System.IO.File.WriteAllBytes(filePath, imageDataByteArray);

            return true;
        }
    }
}
