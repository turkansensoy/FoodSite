using Entities.Concrete;

namespace Business.Abstract
{
    public interface IRecipeMenuService
    {
        String Add(RecipeMenu recipeMenu);
        String Update(RecipeMenu recipeMenu);
        RecipeMenu GetById(int id);
    }
}
