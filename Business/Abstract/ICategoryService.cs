using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        String Add(Category category);
        String Update(Category category);
        String Delete(Category category);
        Category GetById(int id);
    }
}
