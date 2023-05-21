using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodSiteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _categoryService.GetAll();
            return Ok(result);

        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!string.IsNullOrWhiteSpace(category.Image))
            {
                byte[] imgBytes = Convert.FromBase64String(category.Image);
                string fileName = $"{Guid.NewGuid()}_{category.CategoryName.Trim()}.jpeg";
                string image = await UploadFile(imgBytes, fileName);
                category.Image = image;
            }
            _categoryService.Add(category);
            return Ok(category);
        }
        private async Task<string> UploadFile(byte[] bytes, string fileName)
        {
            string uploadsFolder = Path.Combine("Images", fileName);
            Stream stream = new MemoryStream(bytes);
            using (var ms = new FileStream(uploadsFolder, FileMode.Create))
            {
                await stream.CopyToAsync(ms);
            }
            return uploadsFolder;
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (category.Image.Contains("jpeg") != true)
            {
                if (!string.IsNullOrWhiteSpace(category.Image))
                {
                    byte[] imgBytes = Convert.FromBase64String(category.Image);
                    string fileName = $"{Guid.NewGuid()}_{category.CategoryName.Trim()}.jpeg";
                    string image = await UploadFile(imgBytes, fileName);
                    category.Image = image;
                }
            }
            _categoryService.Update(category);
            return Ok(category);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            var category = _categoryService.GetById(id);
            return Ok(_categoryService.Delete(category));

        }
        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute(Name ="id")] int id) 
        {
           var category= _categoryService.GetById(id);
            return Ok(category);
        }
    }
}
