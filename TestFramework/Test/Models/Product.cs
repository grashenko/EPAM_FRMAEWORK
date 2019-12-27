using System.Collections.Generic;

namespace TestFramework.Test.Models
{
    public class Product
    {
        public List<string> Compare { get; set; }
        public string Manufacturer { get; set; }
        public int CountInCart { get; set; }
        public string AddToCart { get; set; }
        public string Search { get; set; }
    }
}
