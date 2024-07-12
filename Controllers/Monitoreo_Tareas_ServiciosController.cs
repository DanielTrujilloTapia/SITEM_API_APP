using Microsoft.AspNetCore.Mvc;
using SITEM_API_APP.Model;
using SITEM_API_APP.Repositories;

namespace SITEM_API_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Monitoreo_Tareas_ServiciosController: ControllerBase
    {
        private readonly IMonitoreoTareaServicioRepository _monitoreoTareaServicioRepository;

        public Monitoreo_Tareas_ServiciosController(IMonitoreoTareaServicioRepository monitoreoTareaServicioRepository)
        {
            _monitoreoTareaServicioRepository=monitoreoTareaServicioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMonitoreoTareasServicios()
        {
            return Ok(await _monitoreoTareaServicioRepository.GetAllMonitoreoTareaServicio ());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GeDetailsMonitoreoTareasServicios(int id)
        {
            return Ok(await _monitoreoTareaServicioRepository.GetDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateMonitoreoTareasServicios([FromBody] monitoreo_tarea_servicio monitoreo_Tarea_servicio)
        {
            if (monitoreo_Tarea_servicio == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _monitoreoTareaServicioRepository.InsertMonitoreoTareaServicio(monitoreo_Tarea_servicio);

            return Created("created", created);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateMonitoreoTareasServicios([FromBody] monitoreo_tarea_servicio monitoreo_Tarea_servicio)
        {
            if (monitoreo_Tarea_servicio == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _monitoreoTareaServicioRepository.UpdateMonitoreoTareaServicio(monitoreo_Tarea_servicio);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMonitoreoTareasServicios(int id)
        {
            await _monitoreoTareaServicioRepository.DeleteMonitoreoTareaServicio(new monitoreo_tarea_servicio { Id_monitoreo_servicio = id });

            return NoContent();
        }
    }
}
