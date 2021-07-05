using AutoMapper;
using ECommerce.Api.Controllers;
using ECommerce.Application.DTO;
using ECommerce.Domain.Models;
using ECommerce.Domain.Services;
using ECommerce.Core.Notifications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ECommerce.Domain.Filter;

namespace ECommerce.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/products")]
    public class ProductsController : MainController
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IMapper mapper,
                                      IProductService productService,
                                      INotifier notifier) : base(notifier)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet("subcategory/{subcategoryId:guid}")]
        public async Task<IActionResult> Find(Guid subcategoryId, [FromQuery] ProductFilter filter)
        {
            var result = await _productService.Find(subcategoryId, filter);
            return CustomResponse(new { list = _mapper.Map<List<ProductResponseDTO>>(result.Item1), count = result.Item2 });
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProductResponseDTO>> FindById(Guid id)
        {
            var register = await Search(id);

            if (register == null) return NotFound();

            return register;
        }

        [HttpPost]
        public async Task<ActionResult<ProductResponseDTO>> Add(ProductAddRequestDTO productDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _productService.Add(_mapper.Map<Product>(productDTO));

            return CustomResponse(productDTO);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ProductResponseDTO>> Update(Guid id, ProductUpdateRequestDTO productDTO)
        {
            if (id != productDTO.Id)
            {
                NotificateError("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(productDTO);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _productService.Update(_mapper.Map<Product>(productDTO));

            return CustomResponse(productDTO);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProductResponseDTO>> Remove(Guid id)
        {
            var productDTO = await Search(id);

            if (productDTO == null) return NotFound();

            await _productService.Remove(id);

            return CustomResponse(productDTO);
        }

        private async Task<ProductResponseDTO> Search(Guid id)
        {
            return _mapper.Map<ProductResponseDTO>(await _productService.FindById(id));
        }

        [HttpPut("{id:guid}/images")]
        public async Task<ActionResult<ImageResponseDTO>> AddImage(Guid id, ImageAddRequestDTO imageDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var imageName = Guid.NewGuid() + "_" + imageDTO.Image;
            if (!FileUpload(imageDTO.ImageUpload, imageName))
            {
                return CustomResponse(imageDTO);
            }

            imageDTO.Image = imageName;

            await _productService.AddImage(new Image(imageDTO.Image, id));

            return CustomResponse(new ImageResponseDTO { Name = imageName });
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
