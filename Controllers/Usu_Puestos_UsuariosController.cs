using Microsoft.AspNetCore.Mvc;
using SITEM_API_APP.Model;
using SITEM_API_APP.Repositories;

namespace SITEM_API_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Usu_Puestos_UsuariosController: ControllerBase
    {
        private readonly IPuestoUsuarioRepository _puestousuarioRepository;

        public Usu_Puestos_UsuariosController(IPuestoUsuarioRepository puestousuarioRepository)
        {
            _puestousuarioRepository=puestousuarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPuestos()
        {
            return Ok(await _puestousuarioRepository.GetAllPuesto());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GeDetailsPuestos(int id)
        {
            return Ok(await _puestousuarioRepository.GetDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePuestos([FromBody] usu_puesto_usuario usu_Puesto_usuario)
        {
            if (usu_Puesto_usuario == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _puestousuarioRepository.InsertPuesto(usu_Puesto_usuario);

            return Created("created", created);
        }


        [HttpPut]
        public async Task<IActionResult> UpdatePuestos([FromBody] usu_puesto_usuario usu_Puesto_usuario)
        {
            if (usu_Puesto_usuario == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _puestousuarioRepository.UpdatePuesto(usu_Puesto_usuario);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePuestos(int id)
        {
            await _puestousuarioRepository.DeletePuesto(new usu_puesto_usuario { Id_puesto = id });

            return NoContent();
        }
    }
}
