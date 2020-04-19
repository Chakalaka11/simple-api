using System.Collections.Generic;

namespace ProductApi.Context
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }

        public List<ReservedProduct> ReservedProducts { get; set; }
    }
}