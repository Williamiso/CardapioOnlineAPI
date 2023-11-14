using CardapioOnlineAPI.Dto;
using CardapioOnlineAPI.Models;
using CardapioOnlineAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

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


        [HttpGet("{id}")]
        public IActionResult GetMenuItemById(int id)
        {
            var menuItem = _service.GetMenuItemById(id);

            if (menuItem == null)
            {
                return NotFound();
            }

            return Ok(menuItem);
        }

        [HttpDelete]
        public IActionResult DeleteMenuItem(int id)
        {
            var menuItem = _service.GetMenuItemById(id);

            if (menuItem == null)
            {
                return NotFound();
            }

            _service.DeleteMenuItem(id);
            return NoContent();
        }

        [HttpPost("{id}/upload/")]
        public async Task<IActionResult> UploadImage(int id, IFormFile file)
        {
            var menuItem = _service.GetMenuItemById(id);

            if (menuItem == null)
            {
                return NotFound();
            }

            if (file == null)
            {
                return BadRequest();
            }

            string uploadsFolder = Path.Combine(@"C:\temp\upload");
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.Name;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            menuItem.ImageUrl = filePath;
            _service.UpdateMenuItem(id, menuItem);


            return Ok();
        }

    }
}
