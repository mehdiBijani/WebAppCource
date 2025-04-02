using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper_Sample.Interfaces;
using Dapper_Sample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dapper_Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetList()
        {
            return _productRepository.GetList();
        }
        
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Product> Get(int id)
        {
            return _productRepository.Load(id);
        }
        
        [HttpPost]
        public ActionResult Add(Product instance)
        {
            _productRepository.Add(instance);

            return Ok();
        }
        
        [HttpPost]
        [Route("Edit")]
        public ActionResult Update(Product instance)
        {
            _productRepository.Update(instance);

            return Ok();
        }
        
        [HttpPost]
        [Route("Delete{id}")]
        public ActionResult Update(int id)
        {
            _productRepository.Delete(id);

            return Ok();
        }
    }
}
