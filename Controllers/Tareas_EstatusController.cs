using Microsoft.AspNetCore.Mvc;
using SITEM_API_APP.Model;
using SITEM_API_APP.Repositories;

namespace SITEM_API_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tareas_EstatusController: ControllerBase
    {
        private readonly IEstatusRepository _estatusRepository;

        public Tareas_EstatusController(IEstatusRepository estatusRepository)
        {
            _estatusRepository=estatusRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEstatu()
        {
            return Ok(await _estatusRepository.GetAllEstatus());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GeDetailsEstatu(int id)
        {
            return Ok(await _estatusRepository.GetDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateEstatu([FromBody] tareas_estatus tareas_Estatus)
        {
            if (tareas_Estatus == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _estatusRepository.InsertEstatus(tareas_Estatus);

            return Created("created", created);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateEstatu([FromBody] tareas_estatus tareas_Estatus)
        {
            if (tareas_Estatus == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _estatusRepository.UpdateEstatus(tareas_Estatus);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEstatu(int id)
        {
            await _estatusRepository.DeleteEstatus(new tareas_estatus { Id_estatus = id });

            return NoContent();
        }
    }
}
