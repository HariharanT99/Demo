using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebToken.Data;
using WebToken.Model;
using WebToken.Services;

namespace WebToken.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        [HttpPost("PostPeoduct")]
        public async Task<ServiceResponse<string>> PostProduct(Product product)
        {
            ServiceResponse<string> response = new();
            response = await _productRepository.CreateProduct(product);

            if (response.Success)
            {
                response.Message = "Product Added successfully";
            }

            return response;
        }

        [HttpGet("GetProduct")]
        public ServiceResponse<List<Product>> GetProduct()
        {
            ServiceResponse<List<Product>> response = new();
            try
            {
                response = _productRepository.GetProduct();

            }
            catch
            {
            }
            return response;
        }
    }
}
