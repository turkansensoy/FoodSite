using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodSiteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        private readonly IRecipeMaterialService _recipeMaterialService;
        private readonly IMaterialService _materialService;
        public RecipesController(IRecipeService recipeService, IRecipeMaterialService recipeMaterialService, IMaterialService materialService)
        {
            _recipeService = recipeService;
            _recipeMaterialService = recipeMaterialService;
            _materialService = materialService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _recipeService.GetAllRecipeDto();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] RecipeMaterialAddDto recipe)
        {
            var recipeMaterialDto = new Recipe()
            {
                RecipeName = recipe.RecipeName,
                NumberofPerson = recipe.NumberofPerson,
                RecipeContent = recipe.RecipeContent,
                PreparationTime = recipe.PreparationTime,
                CookingTime = recipe.CookingTime,
                UserEmail = recipe.UserEmail,
                UserName = recipe.UserName,
                RecipeDateTime = DateTime.Now,
                IsConfirm = recipe.IsConfirm,
                IsSend = recipe.IsSend,
                IsTurnBack=recipe.IsTurnBack,
                CategoryId = recipe.CategoryId
            };

            if (!string.IsNullOrWhiteSpace(recipe.Image))
            {
                byte[] imgBytes = Convert.FromBase64String(recipe.Image);
                string fileName = $"{Guid.NewGuid()}_{recipeMaterialDto.RecipeName.Trim()}_{recipeMaterialDto.RecipeName.Trim()}.jpeg";
                string image = await UploadFile(imgBytes, fileName);
                recipeMaterialDto.Image = image;
            }
            _recipeService.Add(recipeMaterialDto);

            foreach (var item in recipe.recipeMaterialDtos)
            {
                var createRecipeMaterial = new RecipeMaterial()
                {
                    RecipeId = recipeMaterialDto.Id,
                    MaterialId = item.MaterialId,
                    MaterialNumber = item.MaterialNumber,
                    Guantity = item.Guantity
                };
                _recipeMaterialService.Add(createRecipeMaterial);
            }
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
        public async Task<IActionResult> UpdateAsync([FromBody] RecipeDto recipe)
        {
            var recipeMaterialDto = new Recipe()
            {
                Id = recipe.Id,
                RecipeName = recipe.RecipeName,
                NumberofPerson = recipe.NumberofPerson,
                RecipeContent = recipe.RecipeContent,
                PreparationTime = recipe.PreparationTime,
                CookingTime = recipe.CookingTime,
                UserEmail = recipe.UserEmail,
                UserName = recipe.UserName,
                RecipeDateTime = DateTime.Now,
                IsConfirm = recipe.IsConfirm,
                IsSend = recipe.IsSend,
                IsTurnBack= recipe.IsTurnBack,
                CategoryId = recipe.CategoryId
            };

            if (recipe.Image.Contains("jpeg") != true)
            {
                if (!string.IsNullOrWhiteSpace(recipe.Image))
                {
                    byte[] imgBytes = Convert.FromBase64String(recipe.Image);
                    string fileName = $"{Guid.NewGuid()}_{recipeMaterialDto.RecipeName.Trim()}.jpeg";
                    string image = await UploadFile(imgBytes, fileName);
                    recipeMaterialDto.Image = image;
                }
            }
            recipeMaterialDto.Image = recipe.Image;

            _recipeService.Update(recipeMaterialDto);

            foreach (var item in recipe.recipeMaterialDtos)
            {
                var result = _recipeMaterialService.GetByMultiSelectMaterialDto(item.Id);
                if (result != null)
                {
                    var createRecipeMaterial = new RecipeMaterial()
                    {
                        Id = item.Id,
                        RecipeId = recipeMaterialDto.Id,
                        MaterialId = item.MaterialId,
                        MaterialNumber = item.MaterialNumber,
                        Guantity = item.Guantity
                    };
                    _recipeMaterialService.Update(createRecipeMaterial);
                }
                else
                {
                    var createRecipeMaterial1 = new RecipeMaterial()
                    {
                        RecipeId = recipeMaterialDto.Id,
                        MaterialId = item.MaterialId,
                        MaterialNumber = item.MaterialNumber,
                        Guantity = item.Guantity
                    };
                    _recipeMaterialService.Add(createRecipeMaterial1);
                }

            }
            return Ok(recipe);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            var recipe = _recipeService.GetById(id);
            var deletedRecipe = _recipeService.Delete(recipe);
            return Ok();
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute(Name = "id")] int id)
        {
            var recipe = _recipeService.GetById(id);
            return Ok(recipe);

        }
        [HttpGet("{materialName}")]
        public IActionResult GetAllRecipeEngine([FromRoute(Name = "materialName")] string materialName)
        {
            var result = _recipeService.GetAllRecipeEngine(materialName);
            List<RecipeEngineDto> recipeEngineDtos = new List<RecipeEngineDto>();
            foreach (var item in result)
            {
                if (item.IsConfirm == true)
                {
                    RecipeEngineDto recipeEngineDto = new()
                    {
                        Id = item.Id,
                        RecipeName = item.RecipeName,
                        IsConfirm = item.IsConfirm,
                    };
                    var response = _materialService.GetByMultiSelectMaterialDto(item.Id);
                    recipeEngineDto.MaterialDtos = new List<MaterialDto>();
                    foreach (var item1 in response)
                    {
                        MaterialDto materialDto = new()
                        {
                            Id = item1.id,
                            MaterialName = item1.MaterialName,
                        };
                        recipeEngineDto.MaterialDtos.Add(materialDto);
                    }
                    recipeEngineDtos.Add(recipeEngineDto);
                }
            }
            return Ok(recipeEngineDtos);
        }
        [HttpGet("listWhatToDo")]
        public IActionResult GetAllEngine()
        {
            var result = _recipeService.GetAllEngine();
            List<RecipeEngineDto> recipeEngineDtos = new List<RecipeEngineDto>();
            foreach (var item in result)
            {
                if (item.IsConfirm == true)
                {
                    RecipeEngineDto recipeEngineDto = new()
                    {
                        Id = item.Id,
                        RecipeName = item.RecipeName,
                        IsConfirm = item.IsConfirm,
                    };
                    var response = _materialService.GetByMultiSelectMaterialDto(item.Id);
                    recipeEngineDto.MaterialDtos = new List<MaterialDto>();
                    foreach (var item1 in response)
                    {
                        MaterialDto materialDto = new()
                        {
                            Id = item1.id,
                            MaterialName = item1.MaterialName,
                        };
                        recipeEngineDto.MaterialDtos.Add(materialDto);
                    }
                    recipeEngineDtos.Add(recipeEngineDto);
                }
            }
            return Ok(recipeEngineDtos);
        }
    }

}
