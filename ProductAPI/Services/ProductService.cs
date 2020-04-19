using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductApi.Context;
using ProductApi.Models;

namespace ProductApi.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductContext _productContext;

        public ProductService(ProductContext productContext)
        {
            _productContext = productContext;
        }
        public async Task<List<ProductModel>> GetProducts()
        {
            var result = await _productContext.Products
                .Select(x => new ProductModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Amount = x.Amount
                })
                .ToListAsync();
            return result;
        }

        public async Task ReserveProduct(ReserveProductModel model)
        {
            var product = await _productContext.Products
                .FirstOrDefaultAsync(x => x.Id == model.ProductId);
            if (product == null)
            {
                throw new System.Exception($"Product with id {model.ProductId} does not exist");
            }
            product.Amount = product.Amount - 1;

            var reservation = new ReservedProduct()
            {
                ClientId = model.ClientId,
                ProductId = model.ProductId,
                CreatedAt = DateTime.UtcNow
            };
            _productContext.ReservedProducts.Add(reservation);

            await _productContext.SaveChangesAsync();
        }
    }
}