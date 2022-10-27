using Microsoft.AspNetCore.Mvc;
using sic_cms.Entities;
using sic_cms.Services;

namespace sic_cms.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase {

        private readonly IMenuService _service;

        public MenuController(IMenuService service) {

            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Menu menu) => Ok(await _service.Create(menu));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            await _service.Delete(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Menu menu) {
            await _service.Update(menu);

            // confirmação que foi atualizado
            return NoContent();
        }


    }
}
