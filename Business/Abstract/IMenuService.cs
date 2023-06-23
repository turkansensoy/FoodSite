using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMenuService
    {
        String Add(Menu menu);
        String Delete(Menu menu);
        String Update(Menu menu);
        Menu GetById(int id);
        List<Menu> GetAll();
        List<MenuRecipeGetDto> GetAllMenu(int menuId);

    }
}
