using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using TestFramework.Test.Models;

namespace TestFramework.Test.Services
{
    public class ProductCreator
    {
        public static Product CreateProduct(IConfiguration configuration)
        {
            var product = new Product
            {
                AddToCart = configuration["product:addToCart"],
                CountInCart = configuration.GetValue<int>("product:countInCart"),
                Search = configuration["product:search"]
            };
            return product;
        }
    }
}
