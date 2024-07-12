using Microsoft.AspNetCore.Mvc;
using SITEM_API_APP.Model;
using SITEM_API_APP.Repositories;

namespace SITEM_API_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Cat_PlantasController: ControllerBase
    {
        private readonly IPlantasRepository _plantasRepository;

        public Cat_PlantasController(IPlantasRepository plantasRepository)
        {
            _plantasRepository=plantasRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlanta()
        {
            return Ok(await _plantasRepository.GetAllPlantas());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GeDetailsPlanta(int id)
        {
            return Ok(await _plantasRepository.GetDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlanta([FromBody] cat_plantas cat_Plantas)
        {
            if (cat_Plantas == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _plantasRepository.InsertPlantas(cat_Plantas);

            return Created("created", created);
        }


        [HttpPut]
        public async Task<IActionResult> UpdatePlanta([FromBody] cat_plantas cat_Plantas)
        {
            if (cat_Plantas == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _plantasRepository.UpdatePlantas(cat_Plantas);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePlanta(int id)
        {
            await _plantasRepository.DeletePlantas(new cat_plantas { Id_planta = id });

            return NoContent();
        }
    }
}
