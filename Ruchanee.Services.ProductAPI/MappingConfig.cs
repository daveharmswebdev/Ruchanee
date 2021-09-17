using AutoMapper;
using Ruchanee.Services.ProductAPI.Models;
using Ruchanee.Services.ProductAPI.Models.Dtos;

namespace Ruchanee.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>();
                config.CreateMap<Product, ProductDto>();
            });

            return mappingConfig;
        }
    }
}
