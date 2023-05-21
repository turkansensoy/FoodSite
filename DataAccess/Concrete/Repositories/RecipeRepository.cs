using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Repositories
{
    public class RecipeRepository : EFRepositoryBase<Recipe, BaseDbContext>, IRecipeRepository
    {
        public List<RecipeDto> GetAllRecipe()
        {
            using (BaseDbContext context = new())
            {
                var result = from m in context.Recipes
                             select new RecipeDto
                             {
                                 Id = m.Id,
                                 RecipeName = m.RecipeName,
                                 IsSend = m.IsSend,
                                 IsConfirm = m.IsConfirm,
                                 IsTurnBack = m.IsTurnBack,
                                 RecipeContent = m.RecipeContent,
                                 RecipeDateTime = m.RecipeDateTime,
                                 Image = m.Image,
                                 NumberofPerson = m.NumberofPerson,
                                 CookingTime = m.CookingTime,
                                 PreparationTime = m.PreparationTime,
                                 CategoryId = m.CategoryId,
                                 UserName = m.UserName,
                                 UserEmail = m.UserEmail,
                             };
                return result.ToList();
            }
        }
        public List<RecipeEngineDto> GetAllRecipeEngine(int materialId)
        {
            using (BaseDbContext context = new())
            {

                var result = (from m in context.Materials
                              join recipeMaterial in context.RecipeMaterials on m.Id equals recipeMaterial.MaterialId
                              join recipe in context.Recipes on recipeMaterial.RecipeId equals recipe.Id
                              where m.Id == materialId
                              select new RecipeEngineDto
                              {
                                  Id = recipe.Id,
                                  RecipeName = recipe.RecipeName,
                                  IsConfirm = recipe.IsConfirm,
                              }).ToList();
                return result;
            }

        }
        public List<RecipeEngineDto> GetAllEngine()
        {
            using (BaseDbContext context = new())
            {
                var result = from recipe in context.Recipes
                             select new RecipeEngineDto
                             {
                                 Id = recipe.Id,
                                 RecipeName = recipe.RecipeName,
                                 IsConfirm = recipe.IsConfirm
                             };
                return result.ToList();
            }
        }
    }
}
