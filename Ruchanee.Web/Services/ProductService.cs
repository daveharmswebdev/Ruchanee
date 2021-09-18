﻿using Ruchanee.Web.Models;
using Ruchanee.Web.Services.IServices;
using static Ruchanee.Web.SD;

namespace Ruchanee.Web.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory _clientFactory;
        public ProductService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> CreateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = ApiType.POST,
                Data = productDto,
                Url = ProductAPIBase + ApiProductsUrl,
                AccessToken = ""
            });
        }

        public async Task<T> DeleteProductAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = ApiType.DELETE,
                Url = ProductAPIBase + ApiProductsUrl + '/' + id,
                AccessToken = ""
            });
        }

        public async Task<T> GetAllProductsAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = ApiType.GET,
                Url = ProductAPIBase + ApiProductsUrl,
                AccessToken = ""
            });
        }

        public async Task<T> GetProductByIdAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = ApiType.GET,
                Url = ProductAPIBase + ApiProductsUrl + '/' + id,
                AccessToken = ""
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = ApiType.PUT,
                Data = productDto,
                Url = ProductAPIBase + ApiProductsUrl,
                AccessToken = ""
            });
        }
    }
}
