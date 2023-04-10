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
            var createdCategory = new Category
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
            };
            if (!string.IsNullOrWhiteSpace(category.Image))
            {
                byte[] imgBytes = Convert.FromBase64String(category.Image);
                string fileName = $"{Guid.NewGuid()}_{createdCategory.CategoryName.Trim()}.jpeg";
                string image = await UploadFile(imgBytes, fileName);
                createdCategory.Image = image;
            }
            var result = _categoryService.Add(category);
            return Ok(result);


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
        public IActionResult Update([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = _categoryService.Update(category);
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            var category = _categoryService.GetById(id);
            return Ok(_categoryService.Delete(category));

        }
    }
}
