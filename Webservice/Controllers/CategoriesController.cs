using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Assignment4New;
using Assignment4New.Models;
using Microsoft.AspNetCore.Mvc;

namespace Webservice.Controllers
{
    [Route("api/categories")]
    public class CategoriesController : Controller
    {
        DataService _dataService;

        public CategoriesController(DataService dataService)
        {
            _dataService = dataService;
        }


        [HttpGet]
        public IActionResult GetCategories()
        {
            var data = _dataService.GetCategories();

            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategories(int id)
        {
            var data = _dataService.GetCategory(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody]Category category)
        {
            if (category == null)
            {
                return NotFound();
            }
            var data =_dataService.CreateCategory(category.Name, category.Description);
            //201? Created
            return Created("", data);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, [FromBody]Category category)
        {
            var data = _dataService.UpdateCategory(id, category.Name, category.Description);
            if (!data)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult deleteCategory(int id)
        {
            var result =_dataService.DeleteCategory(id);
            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }



    }
}