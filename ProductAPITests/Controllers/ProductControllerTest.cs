using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProductApi;
using ProductApi.Models;
using Xunit;

namespace ProductAPITests
{
    public class ProductControllerTest : IClassFixture<ProductApiApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly ProductModel _referenceProduct;
        public ProductControllerTest(ProductApiApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
            _referenceProduct = new ProductModel()
            {
                Id = 1,
                Amount = 10,
                Name = "Pen"
            };
        }
        [Fact]
        public async Task CanGetProducts()
        {
            // The endpoint or route of the controller action.
            var httpResponse = await _client.GetAsync("/product");

            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<ProductModel>>(stringResponse);
            var testedProduct = products.Find(x => x.Id == _referenceProduct.Id);
            Assert.Equal(testedProduct.Name, _referenceProduct.Name);
            Assert.Equal(testedProduct.Amount, _referenceProduct.Amount);
        }
    }
}
