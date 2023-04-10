using Entities.Concrete;

namespace Business.Abstract
{
    public interface IRecipeService
    {
        List<Recipe> GetAll();
        String Add(Recipe recipe);
        String Update(Recipe recipe);
        String Delete(Recipe recipe);
        Recipe GetById(int id);
    }
}
