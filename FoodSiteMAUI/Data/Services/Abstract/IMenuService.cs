using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSiteMAUI.Data.Services.Abstract
{
    public interface IMenuService
    {
        Task<Menu> Add(RecipeMenuDto recipeMenuDto);
        Task<List<GetRecipeMenuDto>> GetAllMenuRecipe();
        Task<List<GetRecipeMenuDto>> GetById(int id);
    }
}
