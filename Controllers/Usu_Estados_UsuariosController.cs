using Microsoft.AspNetCore.Mvc;
using SITEM_API_APP.Model;
using SITEM_API_APP.Repositories;

namespace SITEM_API_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Usu_Estados_UsuariosController: ControllerBase
    {
        private readonly IEstadoUsuarioRepository _estadousuarioRepository;

        public Usu_Estados_UsuariosController(IEstadoUsuarioRepository estadousuarioRepository)
        {
            _estadousuarioRepository=estadousuarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEstados()
        {
            return Ok(await _estadousuarioRepository.GetAllEstado());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GeDetailsEstados(int id)
        {
            return Ok(await _estadousuarioRepository.GetDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateEstados([FromBody] usu_estado_usuario usu_Estado_usuario)
        {
            if (usu_Estado_usuario == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _estadousuarioRepository.InsertEstado(usu_Estado_usuario);

            return Created("created", created);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateEstados([FromBody] usu_estado_usuario usu_Estado_usuario)
        {
            if (usu_Estado_usuario == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _estadousuarioRepository.UpdateEstado(usu_Estado_usuario);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEstados(int id)
        {
            await _estadousuarioRepository.DeleteEstado(new usu_estado_usuario { Id_estado = id });

            return NoContent();
        }
    }
}
