using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebAPI.Entities;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return _productService.GetProducts();
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(Guid id)
        {
            return _productService.GetProductById(id);
        }

        [HttpPost]
        public ActionResult CreateNewProduct(Product product)
        {
            _productService.CreateProduct(product);
            return CreatedAtAction("GetProductById", new { id = product.Id }, product);
        }

        [HttpPut]
        public ActionResult UpdateStand(Product product)
        {
            _productService.UpdateProduct(product);
            return NoContent();
        }

        [HttpDelete]
        public ActionResult RemoveStand(Product product)
        {
            _productService.RemoveProduct(product);
            return NoContent();
        }
    }
}
