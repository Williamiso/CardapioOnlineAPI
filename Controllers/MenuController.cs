using CardapioOnlineAPI.Dto;
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
        public IActionResult GetAllMenuItems()
        {
           var resposta = _service.GetAllMenuItems();

            if(resposta == null)
            {
                return new NotFoundResult();
            }

            return Ok(resposta);
        }

        [HttpPost]
        public void AddMenuItem([FromBody] CreateRequest request)
        {
            _service.AddMenuItem(request);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMenuItem(int id, [FromBody] UpdateRequest request)
        {
            if(id != request.Id)
            {
                return BadRequest();
            }

            var menuModel = new MenuModel
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Id = request.Id
            };

            _service.UpdateMenuItem(id, menuModel);

            return NoContent();
        }
    }
}
