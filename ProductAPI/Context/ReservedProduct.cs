using System;

namespace ProductApi.Context
{
    public class ReservedProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ClientId { get; set; }
        public DateTime CreatedAt { get; set; }

        public Product Product { get; set; }
        public Client Client { get; set; }
    }
}