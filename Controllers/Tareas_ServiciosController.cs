using Microsoft.AspNetCore.Mvc;
using SITEM_API_APP.Model;
using SITEM_API_APP.Repositories;

namespace SITEM_API_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tareas_ServiciosController: ControllerBase
    {
        private readonly ITareaServicioRepository _tareaServicioRepository;

        public Tareas_ServiciosController(ITareaServicioRepository tareaServicioRepository)
        {
            _tareaServicioRepository=tareaServicioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTareaServicios()
        {
            return Ok(await _tareaServicioRepository.GetAllTareaServicio());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GeDetailsTareaServicios(int id)
        {
            return Ok(await _tareaServicioRepository.GetDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTareaServicios([FromBody] tarea_servicio tarea_Servicio)
        {
            if (tarea_Servicio == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _tareaServicioRepository.InsertTareaServicio(tarea_Servicio);

            return Created("created", created);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateTareaServicios([FromBody] tarea_servicio tarea_Servicio)
        {
            if (tarea_Servicio == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _tareaServicioRepository.UpdateTareaServicio(tarea_Servicio);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTareaServicios(int id)
        {
            await _tareaServicioRepository.DeleteTareaServicio(new tarea_servicio { Id_tarea_servicio = id });

            return NoContent();
        }
    }
}
