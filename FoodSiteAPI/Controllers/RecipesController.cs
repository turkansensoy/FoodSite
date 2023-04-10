using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodSiteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        public RecipesController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _recipeService.GetAll();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Recipe recipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var createdRecipe = new Recipe
            {
                Id = recipe.Id,
                RecipeName = recipe.RecipeName,
                Materials = recipe.Materials,
                RecipeContent = recipe.RecipeContent,
                NumberofPerson = recipe.NumberofPerson,
                PreparationTime = recipe.PreparationTime,
                CookingTime = recipe.CookingTime,
                UserEmail = recipe.UserEmail,
                UserName = recipe.UserName,
                RecipeDateTime = DateTime.Now,
                IsConfirm = recipe.IsConfirm,
                IsSend = recipe.IsSend,
                CategoryId = recipe.CategoryId,

            };
            if (!string.IsNullOrWhiteSpace(recipe.Image))
            {
                byte[] imgBytes = Convert.FromBase64String(recipe.Image);
                string fileName = $"{Guid.NewGuid()}_{createdRecipe.RecipeName.Trim()}.jpeg";
                string image = await UploadFile(imgBytes, fileName);
                createdRecipe.Image = image;
            }
            var result = _recipeService.Add(createdRecipe);
            return Ok(recipe);
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
        public IActionResult Update([FromBody] Recipe recipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = _recipeService.Update(recipe);
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            var recipe = _recipeService.GetById(id);
            var deletedRecipe = _recipeService.Delete(recipe);
            return Ok(deletedRecipe);
        }
    }

}
