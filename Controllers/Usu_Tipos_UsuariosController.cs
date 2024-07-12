using Microsoft.AspNetCore.Mvc;
using SITEM_API_APP.Model;
using SITEM_API_APP.Repositories;

namespace SITEM_API_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Usu_Tipos_UsuariosController: ControllerBase
    {
        private readonly ITipoUsuarioRepository _tipousuarioRepository;

        public Usu_Tipos_UsuariosController(ITipoUsuarioRepository tipousuarioRepository)
        {
            _tipousuarioRepository=tipousuarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTipos()
        {
            return Ok(await _tipousuarioRepository.GetAllTipo());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GeDetailsTipos(int id)
        {
            return Ok(await _tipousuarioRepository.GetDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTipos([FromBody] usu_tipo_usuario usu_Tipo_usuario)
        {
            if (usu_Tipo_usuario == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _tipousuarioRepository.InsertTipo(usu_Tipo_usuario);

            return Created("created", created);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateTipos([FromBody] usu_tipo_usuario usu_Tipo_usuario)
        {
            if (usu_Tipo_usuario == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _tipousuarioRepository.UpdateTipo(usu_Tipo_usuario);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTipos(int id)
        {
            await _tipousuarioRepository.DeleteTipo(new usu_tipo_usuario { Id_tipo = id });

            return NoContent();
        }

    }
}
