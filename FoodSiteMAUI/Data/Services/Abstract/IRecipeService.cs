using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSiteMAUI.Data.Services.Abstract
{
    public interface IRecipeService
    {
        Task<List<RecipeDto>> GetAll();
        Task<Recipe> Add(RecipeMaterialAddDto  recipeMaterialAddDto);
        Task<RecipeDto> Update(RecipeDto recipes);
        void Delete(int id);
        Task<Recipe> GetById(int id);
        Task<List<RecipeEngineDto>> GetRecipeEngineDtos(string materialName);
        Task<List<RecipeEngineDto>> GetAllRecipeEngine();
    }

}
