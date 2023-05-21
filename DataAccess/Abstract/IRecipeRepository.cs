using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        List<RecipeDto> GetAllRecipe();
        // List<RecipeDto>  GetRecipeDto(int id);
        List<RecipeEngineDto> GetAllRecipeEngine(int materialId);
        List<RecipeEngineDto> GetAllEngine();
    }
}
