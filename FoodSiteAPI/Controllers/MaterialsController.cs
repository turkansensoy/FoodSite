using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodSiteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        private readonly IMaterialService _materialService;
        public MaterialsController(IMaterialService materialService)
        {
            _materialService = materialService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _materialService.GetAll();
            return Ok(response);
        }
        [HttpGet("{materialName}")]
        public IActionResult GetByName([FromRoute(Name = "materialName")] string materialName)
        {
           var response= _materialService.GetByName(materialName);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetByMultiSelectMaterial([FromRoute(Name ="id")] int id)
        {
           var response= _materialService.GetByMultiSelectMaterialDto(id);
            return Ok(response);
        }
    }
}
