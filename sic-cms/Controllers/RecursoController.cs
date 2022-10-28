using Microsoft.AspNetCore.Mvc;
using sic_cms.Entities;
using sic_cms.Services;

namespace sic_cms.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class RecursoController : ControllerBase {

        private readonly IRecursoService _service;

        public RecursoController(IRecursoService service) {

            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Recurso Recurso) => Ok(await _service.Create(Recurso));

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> Delete(string codigo) {
            await _service.Delete(codigo);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Recurso Recurso) {
            await _service.Update(Recurso);

            // confirmação que foi atualizado
            return NoContent();
        }

        [HttpGet("{cod}")]
        public async Task<IActionResult> GetByCod(string cod) {
            return Ok(await _service.GetByCod(cod));

         
        }



    }
}
