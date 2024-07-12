using Microsoft.AspNetCore.Mvc;
using SITEM_API_APP.Model;
using SITEM_API_APP.Repositories;

namespace SITEM_API_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tareas_FallasController: ControllerBase
    {
        private readonly ITareaFallaRepository _tareaFallaRepository;

        public Tareas_FallasController(ITareaFallaRepository tareaFallaRepository)
        {
            _tareaFallaRepository=tareaFallaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTareaFallas()
        {
            return Ok(await _tareaFallaRepository.GetAllTareaFalla());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GeDetailsTareaFallas(int id)
        {
            return Ok(await _tareaFallaRepository.GetDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTareaFallas([FromBody] tarea_falla tarea_Falla)
        {
            if (tarea_Falla == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _tareaFallaRepository.InsertTareaFalla(tarea_Falla);

            return Created("created", created);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateTareaFallas([FromBody] tarea_falla tarea_Falla)
        {
            if (tarea_Falla == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _tareaFallaRepository.UpdateTareaFalla(tarea_Falla);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTareaFallas(int id)
        {
            await _tareaFallaRepository.DeleteTareaFalla(new tarea_falla { Id_tarea_falla = id });

            return NoContent();
        }
    }
}
