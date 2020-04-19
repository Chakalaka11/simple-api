using System.Collections.Generic;
using System.Threading.Tasks;
using ProductApi.Models;

namespace ProductApi.Services{
    public interface IProductService
    {
        Task<List<ProductModel>> GetProducts();
        Task ReserveProduct(ReserveProductModel model);
    }
}