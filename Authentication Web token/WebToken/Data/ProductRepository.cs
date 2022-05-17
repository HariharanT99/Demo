using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebToken.Model;
using WebToken.Services;

namespace WebToken.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<string>> CreateProduct(Product product)
        {
            ServiceResponse<string> response = new();

            try
            {
                await _context.AddAsync(product);

                await _context.SaveChangesAsync();
            }
            catch
            {
                response.Success = false;
                response.Message = "Something went wrong";
            }
            return response;
        }

        public ServiceResponse<List<Product>> GetProduct()
        {
            ServiceResponse<List<Product>> response = new();

            try
            {
                response.Data = _context.Products.ToList();
            }
            catch
            {
                response.Success = false;
                response.Message = "Something went wrong";
            }

            return response;
        }
    }
}
