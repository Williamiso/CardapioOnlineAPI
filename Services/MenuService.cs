using CardapioOnlineAPI.Models;
using CardapioOnlineAPI.Repository;

namespace CardapioOnlineAPI.Services
{
    public class MenuService
    {
        private readonly MenuRepository _repository;

        public MenuService(MenuRepository menuRepository)
        {
            _repository = menuRepository;
        }
        public List<MenuModel> GetAllMenuItems()
        {
            return _repository.GetAllMenuItems();
        }

        public void AddMenuItem(MenuModel menuModel)
        {
            _repository.AddMenuItem(menuModel);
        }

        public MenuModel GetMenuItemById(int id) 
        {
            var retorno = _repository.GetMenuItemById(id);

            return retorno;
        }
    }
}
