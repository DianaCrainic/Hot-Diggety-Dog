using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;

namespace WebAPI.Services
{
    public interface IProductService
    {
        ActionResult<IEnumerable<Product>> GetProducts();
        ActionResult<Product> GetProductById(Guid id);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void RemoveProduct(Product product);
    }
}
