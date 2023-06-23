using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Abstract
{
    public interface IMenuRepository : IRepository<Menu>
    {
        List<MenuRecipeGetDto> GetAllMenuRecipe(int menuId);
    }
}
