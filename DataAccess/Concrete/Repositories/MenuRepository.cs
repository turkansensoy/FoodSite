using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Concrete.Repositories
{
    public class MenuRepository : EFRepositoryBase<Menu, BaseDbContext>, IMenuRepository
    {
        public List<MenuRecipeGetDto> GetAllMenuRecipe(int menuId)
        {
            using (BaseDbContext context = new())
            {
                var result = from recipeMenu in context.RecipeMenu
                             join menu in context.Menu on recipeMenu.MenuId equals menu.Id
                             join recipe in context.Recipes on recipeMenu.RecipeId equals recipe.Id
                             where recipeMenu.MenuId == menuId
                             select new MenuRecipeGetDto
                             {
                                 MenuId = menu.Id,
                                 RecipeId = recipe.Id,
                                 RecipeName = recipe.RecipeName,
                                 Image = recipe.Image,
                                 UserName = recipe.UserName,
                             };
                return result.ToList();
            }
        }
    }
}
