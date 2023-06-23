using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodSiteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly IMenuService _menuService;
        private readonly IRecipeMenuService _recipeMenuService;
        public MenusController(IMenuService menuService, IRecipeMenuService recipeMenuService)
        {
            _recipeMenuService = recipeMenuService;
            _menuService = menuService;
        }
        [HttpPost]
        public IActionResult Add([FromBody] RecipeMenuDto recipeMenuDto)
        {
            var menu = new Menu()
            {
                MenuName = recipeMenuDto.MenuName,
            };
            _menuService.Add(menu);
            foreach (var item in recipeMenuDto.Recipes)
            {
                var recipeMenu = new RecipeMenu()
                {
                    RecipeId = item.RecipeId,
                    MenuId = menu.Id,
                };
                _recipeMenuService.Add(recipeMenu);
            }
            return Ok(recipeMenuDto);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Menu> menus = _menuService.GetAll();
            List<GetRecipeMenuDto> getRecipeMenuDtos = new List<GetRecipeMenuDto>();
            foreach (var item in menus)
            {
                GetRecipeMenuDto getRecipeMenu = new()
                {
                    Id = item.Id,
                    MenuName = item.MenuName,
                };
                getRecipeMenuDtos.Add(getRecipeMenu);
                var result = _menuService.GetAllMenu(item.Id);
                if (result != null)
                {
                    getRecipeMenu.MenuRecipeGetDtos = new List<MenuRecipeGetDto>();
                    foreach (var item2 in result)
                    {
                        MenuRecipeGetDto menuRecipeGetDto = new()
                        {
                            RecipeId = item2.RecipeId,
                            MenuId = item2.MenuId,
                            Image = item2.Image,
                            RecipeName = item2.RecipeName,
                            UserName = item2.UserName,
                        };
                        getRecipeMenu.MenuRecipeGetDtos.Add(menuRecipeGetDto);
                    }
                }
            }
            return Ok(getRecipeMenuDtos);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute(Name = "id")] int id)
        {
            var menu = _menuService.GetById(id);
            List<GetRecipeMenuDto> getRecipeMenuDtos = new List<GetRecipeMenuDto>();
            GetRecipeMenuDto getRecipeMenu = new()
            {
                Id = menu.Id,
                MenuName = menu.MenuName,
            };
            getRecipeMenuDtos.Add(getRecipeMenu);
            var result = _menuService.GetAllMenu(menu.Id);
            if (result != null)
            {
                getRecipeMenu.MenuRecipeGetDtos = new List<MenuRecipeGetDto>();
                foreach (var item2 in result)
                {
                    MenuRecipeGetDto menuRecipeGetDto = new()
                    {
                        RecipeId = item2.RecipeId,
                        MenuId = item2.MenuId,
                        Image = item2.Image,
                        RecipeName = item2.RecipeName,
                        UserName = item2.UserName,
                    };
                    getRecipeMenu.MenuRecipeGetDtos.Add(menuRecipeGetDto);
                }
            }
            return Ok(getRecipeMenuDtos);
        }
    }
}
