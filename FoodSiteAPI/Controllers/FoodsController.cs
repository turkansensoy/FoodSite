using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodSiteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        IFoodService _foodService;
        public FoodsController(IFoodService foodService)
        {
            _foodService = foodService;
        }
        [HttpPost]
        public IActionResult Add([FromBody] Food food)
        {
            var result = _foodService.Add(food);
            return Ok(result);
        }
        [HttpPut]
        public IActionResult Update([FromBody] Food food)
        {
            var result = _foodService.Update(food);
            return Ok(result);
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            var food = _foodService.GetById(id);
            var result = _foodService.Delete(food);
            return Ok(result);
        }

    }
}
