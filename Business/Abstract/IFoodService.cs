using Entities.Concrete;

namespace Business.Abstract
{
    public interface IFoodService
    {
        String Add(Food food);
        String Update(Food food);
        String Delete(Food food);
        Food GetById(int id);
    }
}
