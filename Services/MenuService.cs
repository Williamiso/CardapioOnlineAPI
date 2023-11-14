using CardapioOnlineAPI.Dto;
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

        public void AddMenuItem(CreateRequest request)
        {
            var menuModel = new MenuModel()
            {
                Description = request.Description,
                Name = request.Name, 
                Price = request.Price
            };

            _repository.AddMenuItem(menuModel);
        }

        public MenuModel GetMenuItemById(int id) 
        {
            var retorno = _repository.GetMenuItemById(id);

            return retorno;
        }

        public void UpdateMenuItem(int id, MenuModel menuModel)
        {
            var exist = GetMenuItemById(id);

            if(exist != null)
            {
                _repository.UpdateMenuItem(menuModel);
            }
           
        }

        public void DeleteMenuItem(int id)
        {
            _repository.DeleteMenuItem(id);
        }

        
    }
}
