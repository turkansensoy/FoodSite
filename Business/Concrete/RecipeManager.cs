using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RecipeManager : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        public RecipeManager(IRecipeRepository recipeService)
        {
            _recipeRepository = recipeService;   
        }
        public string Add(Recipe recipe)
        {
            _recipeRepository.Add(recipe);
            return "";
        }

        public string Delete(Recipe recipe)
        {
            _recipeRepository.Delete(recipe);
            return "";
        }

        public List<Recipe> GetAll()
        {
           return  _recipeRepository.GetAll();
        }

        public Recipe GetById(int id)
        {
            return _recipeRepository.Get(_=>_.Id== id);
        }

        public string Update(Recipe recipe)
        {
            _recipeRepository.Update(recipe);
            return "";
        }
    }
}
