using CardapioOnlineAPI.Models;

namespace CardapioOnlineAPI.Dto
{
    public class UpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string? ImageUrl { get; set; }

        public static MenuModel FromUpdateRequest(UpdateRequest request)
        {
            return new MenuModel
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                ImageUrl = request.ImageUrl
            };

        }

        public static UpdateRequest FromMenuItem(MenuModel menuItem)
        {
            return new UpdateRequest
            {
                Id = menuItem.Id,
                Name = menuItem.Name,
                Description = menuItem.Description,
                Price = menuItem.Price,
                ImageUrl = menuItem.ImageUrl
            };
        }
    }
}
