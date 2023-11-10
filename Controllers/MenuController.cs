using CardapioOnlineAPI.Models;
using CardapioOnlineAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CardapioOnlineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly MenuService _service;

        public MenuController(MenuService menuService)
        {
            _service = menuService;
        }

        [HttpGet]
        public List<MenuModel> ListarMenu()
        {
           var resposta = _service.GetAllMenuItems();

            return resposta;
        }

        [HttpPost]
        public void AddMenuItem([FromBody] MenuModel menuModel)
        {
            _service.AddMenuItem(menuModel);
        }
    }
}
