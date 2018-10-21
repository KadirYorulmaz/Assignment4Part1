using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment4New;
using Microsoft.AspNetCore.Mvc;

namespace Webservice.Controllers
{

    [Route("api/products")]
    public class ProductsController : Controller
    {
        private DataService _dataService;

        public ProductsController(DataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("{id}")]    
        public IActionResult GetProduct(int id)
        {
            var result = _dataService.GetProduct(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }


        [HttpGet("category/{id}")]
        public IActionResult GetProducts(int id)
        {
            var result = _dataService.GetProductByCategory(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("name/{substring}")]
        public IActionResult GetProductByName(string substring)
        {
            var result = _dataService.GetProductByName(substring);
            Console.WriteLine(result.Count());
            if (result.Count() == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}