using Microsoft.AspNetCore.Mvc;
using SITEM_API_APP.Model;
using SITEM_API_APP.Repositories;

namespace SITEM_API_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Cat_Img_TareasController: ControllerBase
    {
        private readonly ICatImgTareasRepository _catimgtareasRepository;

        public Cat_Img_TareasController(ICatImgTareasRepository catimgtareasRepository)
        {
            _catimgtareasRepository=catimgtareasRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllImgs()
        {
            return Ok(await _catimgtareasRepository.GetAllImg());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GeDetailsImgs(int id)
        {
            return Ok(await _catimgtareasRepository.GetDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateImgs([FromBody] cat_img_tarea cat_Img_tarea)
        {
            if (cat_Img_tarea == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _catimgtareasRepository.InsertImg(cat_Img_tarea);

            return Created("created", created);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateImgs([FromBody] cat_img_tarea cat_Img_tarea)
        {
            if (cat_Img_tarea == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _catimgtareasRepository.UpdateImg(cat_Img_tarea);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteImgs(int id)
        {
            await _catimgtareasRepository.DeleteImg(new cat_img_tarea { Id_img = id });

            return NoContent();
        }
    }
}
