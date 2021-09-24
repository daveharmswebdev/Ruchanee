using Microsoft.AspNetCore.Mvc;
using Ruchanee.Services.ShoppingCartAPI.Models;
using Ruchanee.Services.ShoppingCartAPI.Models.Dtos;
using Ruchanee.Services.ShoppingCartAPI.Repository;

namespace Ruchanee.Services.ShoppingCartAPI.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        protected ResponseDto _response;

        public ShoppingCartController(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _response = new ResponseDto();
        }

        [HttpGet("GetCart/{userId}")]
        public async Task<object> GetCart(string userId)
        {
            try
            {
                CartDto cartDto = await _shoppingCartRepository.GetCartByUserId(userId);
                _response.Result = cartDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost("AddCart")]
        public async Task<object> AddCart([FromBody] CartDto cartDto)
        {
            try
            {
                CartDto returnedCartDto = await _shoppingCartRepository.CreateUpdateCart(cartDto);
                _response.Result = returnedCartDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost("UpdateCart")]
        public async Task<object> UpdateCart([FromBody] CartDto cartDto)
        {
            try
            {
                CartDto returnedCartDto = await _shoppingCartRepository.CreateUpdateCart(cartDto);
                _response.Result = returnedCartDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost("RemoveFromCart")]
        public async Task<object> RemoveFromCart([FromBody] int cartDetailsId)
        {
            try
            {
                var success = await _shoppingCartRepository.RemoveFromCart(cartDetailsId);
                _response.Result = success;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
