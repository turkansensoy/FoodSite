using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodSiteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeMaterialsController : ControllerBase
    {
        private readonly IRecipeMaterialService _recipeMaterialService;
        public RecipeMaterialsController(IRecipeMaterialService recipeMaterialService)
        {
            _recipeMaterialService = recipeMaterialService;
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            var recipeMaterial = _recipeMaterialService.GetById(id);
            var deletedRecipe = _recipeMaterialService.Delete(recipeMaterial);
            return Ok();
        }
    }
}
