using Microsoft.AspNetCore.Mvc;
using SITEM_API_APP.Model;
using SITEM_API_APP.Repositories;

namespace SITEM_API_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Monitoreo_Tareas_FallasController: ControllerBase
    {
        private readonly IMonitoreo_Tarea_FallaRepository _monitoreoTareaFallaRepository;

        public Monitoreo_Tareas_FallasController(IMonitoreo_Tarea_FallaRepository monitoreoTareaFallaRepository)
        {
            _monitoreoTareaFallaRepository=monitoreoTareaFallaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMonitoreoTareasFallas()
        {
            return Ok(await _monitoreoTareaFallaRepository.GetAllMonitoreoTareaFalla());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GeDetailsMonitoreoTareasFallas(int id)
        {
            return Ok(await _monitoreoTareaFallaRepository.GetDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateMonitoreoTareasFallas([FromBody] monitoreo_tarea_falla monitoreo_Tarea_falla)
        {
            if (monitoreo_Tarea_falla == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _monitoreoTareaFallaRepository.InsertMonitoreoTareaFalla(monitoreo_Tarea_falla);

            return Created("created", created);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateMonitoreoTareasFallas([FromBody] monitoreo_tarea_falla monitoreo_Tarea_falla)
        {
            if (monitoreo_Tarea_falla == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _monitoreoTareaFallaRepository.UpdateMonitoreoTareaFalla(monitoreo_Tarea_falla);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMonitoreoTareasFallas(int id)
        {
            await _monitoreoTareaFallaRepository.DeleteMonitoreoTareaFalla(new monitoreo_tarea_falla { Id_monitoreo_falla = id });

            return NoContent();
        }
    }
}
