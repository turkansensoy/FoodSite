using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSiteMAUI.Data.Services.Abstract
{
    public interface IRecipeService
    {
        Task<List<Recipe>> GetAll();
        Task<Recipe> Add(Recipe recipes);
        Task<Recipe> Update(Recipe recipes);
        void Delete(int id);
        Task<Recipe> GetById(int id);
    }
}
