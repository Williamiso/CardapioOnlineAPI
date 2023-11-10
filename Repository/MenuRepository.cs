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
        
    }    
}
