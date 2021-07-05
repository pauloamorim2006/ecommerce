using AutoMapper;
using ECommerce.Api.Controllers;
using ECommerce.Application.DTO;
using ECommerce.Core.Notifications;
using ECommerce.Domain.Models;
using ECommerce.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ECommerce.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/brands")]
    public class ShoppingCartController : MainController
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IMapper _mapper;

        public ShoppingCartController(IMapper mapper,
                                      IShoppingCartService shoppingCartService,
                                      INotifier notifier) : base(notifier)
        {
            _mapper = mapper;
            _shoppingCartService = shoppingCartService;
        }

        [HttpGet("{customerId:guid}")]
        public async Task<ActionResult<ShoppingCartResponseDTO>> Find(Guid customerId)
        {
            var cart = _mapper.Map<ShoppingCartResponseDTO>(await _shoppingCartService.Find(customerId));

            return CustomResponse(cart);
        }

        [HttpPost("{customerId:guid}/add-item")]
        public async Task<ActionResult<ShoppingCartResponseDTO>> AddItem(Guid customerId, ShoppingCartItemRequestDTO item)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            
            var cart = _mapper.Map<ShoppingCartResponseDTO>(await _shoppingCartService.AddShoppingCartItem(customerId, _mapper.Map<ShoppingCartItem>(item)));

            return CustomResponse(cart);
        }

        [HttpPut("{customerId:guid}/update-item")]
        public async Task<ActionResult<ShoppingCartResponseDTO>> UpdateItem(Guid customerId, ShoppingCartItemRequestDTO item)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var cart = _mapper.Map<ShoppingCartResponseDTO>(await _shoppingCartService.UpdateShoppingCartItem(customerId, _mapper.Map<ShoppingCartItem>(item)));

            return CustomResponse(cart);
        }

        [HttpDelete("{customerId:guid}/remove-item")]
        public async Task<ActionResult<ShoppingCartResponseDTO>> RemoveItem(Guid customerId, ShoppingCartItemRemoveRequestDTO item)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var cart = _mapper.Map<ShoppingCartResponseDTO>(await _shoppingCartService.RemoveShoppingCartItem(customerId, _mapper.Map<ShoppingCartItem>(item)));

            return CustomResponse(cart);
        }

        [HttpPut("{customerId:guid}/invoice")]
        public async Task<ActionResult> UpdateStatusInvoice(Guid customerId)
        {
            await _shoppingCartService.UpdateStatusInvoice(customerId);

            return CustomResponse();
        }

        [HttpPut("{customerId:guid}/canceled")]
        public async Task<ActionResult> UpdateStatusCanceled(Guid customerId)
        {
            await _shoppingCartService.UpdateStatusCanceled(customerId);

            return CustomResponse();
        }

    }
}
