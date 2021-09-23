using Ruchanee.Services.ShoppingCartAPI.Models.Dtos;

namespace Ruchanee.Services.ShoppingCartAPI.Repository
{
    public interface IShoppingCartRepository
    {
        Task<CartDto> GetCartBuUserId(string userId);
        Task<CartDto> CreateUpdateCart(CartDto cartDto);
        Task<bool> RemoveFromCart(int cartDetailsId);
        Task<bool> ClearCart(string userId);
    }
}
