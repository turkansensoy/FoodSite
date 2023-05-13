using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
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

        public List<RecipeEngineDto> GetAllEngine()
        {
            return _recipeRepository.GetAllEngine();
        }

        public List<RecipeDto> GetAllRecipeDto()
        {
            return _recipeRepository.GetAllRecipe();
        }

        public List<RecipeEngineDto> GetAllRecipeEngine(string materialName)
        {
            return _recipeRepository.GetAllRecipeEngine(materialName);
        }

        public Recipe GetById(int id)
        {
            return _recipeRepository.Get(_ => _.Id == id);
        }

        public string Update(Recipe recipe)
        {
            _recipeRepository.Update(recipe);
            return "";
        }
    }
}
