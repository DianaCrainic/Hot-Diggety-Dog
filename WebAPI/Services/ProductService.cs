using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Data;
using WebAPI.Entities;

namespace WebAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;

        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return _repository.GetAll().ToList();
        }

        public ActionResult<Product> GetProductById(Guid id)
        {
            return _repository.GetById(id);
        }

        public void CreateProduct(Product product)
        {
            _repository.Create(product);
        }

        public void UpdateProduct(Product product)
        {
            _repository.Update(product);
        }

        public void RemoveProduct(Product product)
        {
            _repository.Remove(product);
        }
    }
}
