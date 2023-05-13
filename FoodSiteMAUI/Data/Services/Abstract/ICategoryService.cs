using Entities.Concrete;

namespace FoodSiteMAUI.Data.Services.Abstract
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAll();
        void Delete(int id);
        Task<Category> Add(Category category);
        Task<Category> Update(Category category);
    }
}
