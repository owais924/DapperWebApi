using DapperWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductIdController : ControllerBase
    {
        private readonly ProductIdRepository productIdRepository;
        
        public ProductIdController()
        {
            productIdRepository = new ProductIdRepository();
        }
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return productIdRepository.GetAll();
        }
        [HttpGet("{ID}")]
        public Product Get(int ID)
        {
            return productIdRepository.GetbyID(ID);
        }
        [HttpPost]
        public void Post([FromBody] Product prod)
        {
            if (ModelState.IsValid)
                productIdRepository.Add(prod);
        }
        [HttpPut("{ID}")]
        public void Put(int ID, [FromBody] Product prod)
        {
            prod.ProductID = ID;
            if (ModelState.IsValid)
                productIdRepository.Update(prod);
        }
        [HttpDelete]
        public void Delete(int ID)
        {
            productIdRepository.Delete(ID);
        }
    }
}
