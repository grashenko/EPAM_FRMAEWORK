using Microsoft.Extensions.Configuration;
using TestFramework.Test.Models;

namespace TestFramework.Test.Services
{
    public static class UserCreator
    {
        public static User CreateUser(IConfiguration configuration)
        {
            var user = new User
            {
                Email = configuration["user:email"],
                Address = configuration["user:address"],
                Password = configuration["user:password"],
                AddressChange = configuration["user:addressChange"],
                Appartement = configuration["user:appartament"]

            };
            return user;
        }
    }
}
