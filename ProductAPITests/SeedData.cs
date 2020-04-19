using System;
using ProductApi.Context;

namespace ProductAPITests
{
    public static class SeedData
    {
        public static void PopulateTestData(ProductContext dbContext)
        {
            dbContext.Products
                .Add(new Product()
                {
                    Id = 1,
                    Amount = 10,
                    Name = "Pen"
                });
            dbContext.Clients
                .Add(new Client()
                {
                    Id = 1,
                    FirstName = "Seth",
                    LastName = "Here"
                });
            dbContext.SaveChanges();
        }
    }
}
