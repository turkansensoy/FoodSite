using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.Repositories
{
    public class FoodRepository: EFRepositoryBase<Food, BaseDbContext>,IFoodRepository 
    { 

    }
}
