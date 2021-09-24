using Ruchanee.Web.Models;
using Ruchanee.Web.Services.IServices;
using static Ruchanee.Web.SD;

namespace Ruchanee.Web.Services
{
    public class ShoppingCartService : BaseService, IShoppingCartService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ShoppingCartService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T> AddToCartAsync<T>(CartDto cartDto, string? token = null)
        {
            return await SendAsync<T>(new ApiRequest
            {
                ApiType = ApiType.POST,
                Data = cartDto,
                Url = ShoppingCartAPIBase + ShoppingCartUrl + "/AddCart",
                AccessToken = token
            });
        }
        public async Task<T> GetCartByUserIdAsync<T>(string userId, string? token = null)
        {
            return await SendAsync<T>(new ApiRequest
            {
                ApiType = ApiType.GET,
                Url = ProductAPIBase + ShoppingCartUrl + "/GetCart/" + userId,
                AccessToken = token
            });
        }

        public async Task<T> RemoveFromCartAsync<T>(int cartId, string? token = null)
        {
            return await SendAsync<T>(new ApiRequest
            {
                ApiType = ApiType.POST,
                Data = cartId,
                Url = ShoppingCartAPIBase + ShoppingCartUrl + "/RemoveFromCart",
                AccessToken = token
            });
        }

        public async Task<T> UpdateCartAsync<T>(CartDto cartDto, string? token = null)
        {
            return await SendAsync<T>(new ApiRequest
            {
                ApiType = ApiType.POST,
                Data = cartDto,
                Url = ShoppingCartAPIBase + ShoppingCartUrl + "/UpdateCart",
                AccessToken = token
            });
        }
    }
}
