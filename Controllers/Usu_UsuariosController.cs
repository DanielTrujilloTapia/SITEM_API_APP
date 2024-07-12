using Microsoft.AspNetCore.Mvc;
using SITEM_API_APP.Model;
using SITEM_API_APP.Repositories;

namespace SITEM_API_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Usu_UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public Usu_UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository=usuarioRepository;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllUsuario()
        {
            return Ok(await _usuarioRepository.GetAllUsuario());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuarioDetails(int id)
        {
            return Ok(await _usuarioRepository.GetDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsuario([FromBody] usu_usuario usu_Usuario)
        {
            if (usu_Usuario == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _usuarioRepository.InsertUsuario(usu_Usuario);

            return Created("created", created);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateUsuario([FromBody] usu_usuario usu_Usuario)
        {
            if (usu_Usuario == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _usuarioRepository.UpdateUsuario(usu_Usuario);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            await _usuarioRepository.DeleteUsuario(new usu_usuario { Id_usuario = id });

            return NoContent();
        }
    }
}
