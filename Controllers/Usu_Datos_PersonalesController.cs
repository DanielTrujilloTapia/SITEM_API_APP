using Microsoft.AspNetCore.Mvc;
using SITEM_API_APP.Model;
using SITEM_API_APP.Repositories;

namespace SITEM_API_APP.Controllers
{
    [Route("api/ [controller]")]
    [ApiController]
    public class Usu_Datos_PersonalesController: ControllerBase
    {
        private readonly IDatosPersonalesRepository _datospersonalesRepository;

        public Usu_Datos_PersonalesController(IDatosPersonalesRepository datospersonalesRepository)
        {
            _datospersonalesRepository=datospersonalesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDato()
        {
            return Ok(await _datospersonalesRepository.GetAllDatos());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GeDetailsDato(int id)
        {
            return Ok(await _datospersonalesRepository.GetDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateDato([FromBody] usu_datos_personales usu_Datos_personales)
        {
            if (usu_Datos_personales == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _datospersonalesRepository.InsertDatos(usu_Datos_personales);

            return Created("created", created);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateDato([FromBody] usu_datos_personales usu_Datos_personales)
        {
            if (usu_Datos_personales == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _datospersonalesRepository.UpdateDatos(usu_Datos_personales);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDato(int id)
        {
            await _datospersonalesRepository.DeleteDatos(new usu_datos_personales { Id_datos = id });

            return NoContent();
        }
    }
}
