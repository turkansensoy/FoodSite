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
    public class FoodManager : IFoodService
    {
        IFoodRepository _foodRepository;
        public FoodManager(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }
        public string Add(Food food)
        {
            _foodRepository.Add(food);
            return "";
        }

        public string Delete(Food food)
        {
            _foodRepository.Delete(food);
            return "";
        }

        public Food GetById(int id)
        {
          return  _foodRepository.Get(f=>f.Id == id);
        }

        public string Update(Food food)
        {
           _foodRepository.Update(food);
            return "";
        }
    }
}
