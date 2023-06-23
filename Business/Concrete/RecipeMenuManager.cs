using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class RecipeMenuManager : IRecipeMenuService
    {
        private readonly IRecipeMenuRepository _recipeMenuRepository;
        public RecipeMenuManager(IRecipeMenuRepository recipeMenuRepository)
        {
            _recipeMenuRepository = recipeMenuRepository;
        }
        public string Add(RecipeMenu recipeMenu)
        {
            _recipeMenuRepository.Add(recipeMenu);
            return "";
        }

        public RecipeMenu GetById(int id)
        {
           return _recipeMenuRepository.Get(_=>_.Id==id);
        }

        public string Update(RecipeMenu recipeMenu)
        {
           _recipeMenuRepository.Update(recipeMenu);
            return "";
        }
    }
}
