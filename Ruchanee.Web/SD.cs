﻿namespace Ruchanee.Web
{
    public static class SD
    {
        public static string ProductAPIBase {  get; set; }
        public static string ShoppingCartAPIBase {  get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE,
        }

        public const string ApplicationJson = "application/json";
        public const string RuchaneeAPI = "RuchaneeAPI";
        public const string ApiProductsUrl = "/api/products";
        public const string ShoppingCartUrl = "/api/cart";
    }
}
