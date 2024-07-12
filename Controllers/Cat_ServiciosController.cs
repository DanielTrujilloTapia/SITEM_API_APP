using Microsoft.AspNetCore.Mvc;
using SITEM_API_APP.Model;
using SITEM_API_APP.Repositories;

namespace SITEM_API_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Cat_ServiciosController: ControllerBase
    {
        private readonly IServiciosRepository _serviciosRepository;

        public Cat_ServiciosController(IServiciosRepository serviciosRepository)
        {
            _serviciosRepository=serviciosRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllServicio()
        {
            return Ok(await _serviciosRepository.GetAllServicios());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GeDetailsServicio(int id)
        {
            return Ok(await _serviciosRepository.GetDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateServicio([FromBody] cat_servicios cat_Servicios)
        {
            if (cat_Servicios == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _serviciosRepository.InsertServicios(cat_Servicios);

            return Created("created", created);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateServicio([FromBody] cat_servicios cat_Servicios)
        {
            if (cat_Servicios == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _serviciosRepository.UpdateServicios(cat_Servicios);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteServicio(int id)
        {
            await _serviciosRepository.DeleteServicios(new cat_servicios { Id_servicio = id });

            return NoContent();
        }
    }
}
