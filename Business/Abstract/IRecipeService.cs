using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface IRecipeService
    {
        List<RecipeDto> GetAllRecipeDto();
        String Add(Recipe recipe);
        String Update(Recipe recipe);
        String Delete(Recipe recipe);
        Recipe GetById(int id);
        List<RecipeEngineDto> GetAllRecipeEngine(string materialName);
        List<RecipeEngineDto> GetAllEngine();
    }
}
