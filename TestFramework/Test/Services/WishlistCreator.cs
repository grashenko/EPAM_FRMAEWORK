using Microsoft.Extensions.Configuration;
using TestFramework.Test.Models;

namespace TestFramework.Test.Services
{
    public static class WishlistCreator
    {
        public static Wishlist CreateWishlist(IConfiguration configuration)
        {
            var wishlist = new Wishlist
            {
                Title = configuration["wishlist:title"],
                Jeans = configuration["wishlist:jeans"]
            };
            return wishlist;
        }
    }
}
