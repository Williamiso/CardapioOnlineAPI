using CardapioOnlineAPI.Dto;
using CardapioOnlineAPI.Models;

namespace CardapioOnlineAPI.Repository
{
    public class MenuRepository
    {
        private static List<MenuModel> menuModels = new List<MenuModel>();

        public void AddMenuItem(MenuModel menuModel)
        {
            menuModel.Id = menuModels.Count + 1;
            menuModels.Add(menuModel);
        }

        public List<MenuModel> GetAllMenuItems()
        {
            return menuModels;
        }

        public MenuModel GetMenuItemById(int id)
        {
            return menuModels.FirstOrDefault(item => item.Id == id);
        }

        public void UpdateMenuItem(MenuModel menuModel)
        {

            {
                var menuModelOld = menuModels.FirstOrDefault(item => item.Id == menuModel.Id);
                menuModelOld.Name = menuModel.Name;
                menuModelOld.Description = menuModel.Description;
                menuModelOld.Price = menuModel.Price;
                menuModelOld.ImageUrl = menuModel.ImageUrl;
            }

        }
        
    }    
}
