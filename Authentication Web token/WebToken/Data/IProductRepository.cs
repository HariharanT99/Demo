using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebToken.Model;
using WebToken.Services;

namespace WebToken.Data
{
    public interface IProductRepository
    {
        Task<ServiceResponse<string>> CreateProduct(Product product);
        ServiceResponse<List<Product>> GetProduct();
    }
}
