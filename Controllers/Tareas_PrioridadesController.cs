using Microsoft.AspNetCore.Mvc;
using SITEM_API_APP.Model;
using SITEM_API_APP.Repositories;

namespace SITEM_API_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tareas_PrioridadesController: ControllerBase
    {
        private readonly IPrioridadRepository _prioridadRepository;

        public Tareas_PrioridadesController(IPrioridadRepository prioridadRepository)
        {
            _prioridadRepository=prioridadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPrioridades()
        {
            return Ok(await _prioridadRepository.GetAllPrioridad());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GeDetailsPrioridades(int id)
        {
            return Ok(await _prioridadRepository.GetDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePrioridades([FromBody] tareas_prioridad tareas_Prioridad)
        {
            if (tareas_Prioridad == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _prioridadRepository.InsertPrioridad(tareas_Prioridad);

            return Created("created", created);
        }


        [HttpPut]
        public async Task<IActionResult> UpdatePrioridades([FromBody] tareas_prioridad tareas_Prioridad)
        {
            if (tareas_Prioridad == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _prioridadRepository.UpdatePrioridad(tareas_Prioridad);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePrioridades(int id)
        {
            await _prioridadRepository.DeletePrioridad(new tareas_prioridad { Id_prioridad = id });

            return NoContent();
        }
    }
}
