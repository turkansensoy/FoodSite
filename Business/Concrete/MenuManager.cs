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
    public class MenuManager: IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        public MenuManager(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }
        public string Add(Menu menu)
        {
            _menuRepository.Add(menu);
            return "";
        }

        public string Delete(Menu menu)
        {
            throw new NotImplementedException();
        }
        public List<Menu> GetAll()
        {
            return _menuRepository.GetAll();
        }
        public List<MenuRecipeGetDto> GetAllMenu(int menuId)
        {
            return _menuRepository.GetAllMenuRecipe(menuId);
        }

        public Menu GetById(int id)
        {
            return _menuRepository.Get(_ => _.Id == id);
        }

        public string Update(Menu menu)
        {
            _menuRepository.Update(menu);
            return "";
        }
    }
}
