using Entities.Concrete;

namespace FoodSiteMAUI.Data.Services.Abstract
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAll();
        Task<Category> Add(Category category);
    }
}
