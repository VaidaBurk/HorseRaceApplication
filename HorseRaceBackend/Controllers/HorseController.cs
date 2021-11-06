using HorseRaceBackend.Dtos;
using HorseRaceBackend.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HorseRaceBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HorseController : Controller
    {
        private readonly HorseService _horseService;

        public HorseController(HorseService horseService)
        {
            _horseService = horseService;
        }

        [HttpGet]
        public async Task<ActionResult> GetHorses()
        {
            return Ok(await _horseService.GetHorsesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetHorse(int id)
        {
            try
            {
                return Ok(await _horseService.GetHorseAsync(id));
            }
            catch (ArgumentNullException exception)
            {
                return StatusCode(404, exception.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddHorse(HorseAddDto newHorse)
        {
            try
            {
                return Ok(await _horseService.AddHorseAsync(newHorse));
            }
            catch (ArgumentException exception)
            {
                return StatusCode(500, exception.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHorse(HorseUpdateDto updatedHorse)
        {
            try
            {
                await _horseService.UpdateHorseAsync(updatedHorse);
                return NoContent();
            }
            catch (ArgumentNullException exception)
            {
                return StatusCode(404, exception.Message);
            }
            catch (ArgumentException exception)
            {
                return StatusCode(500, exception.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveHorse(int id)
        {
            try
            {
                await _horseService.RemoveHorseAsync(id);
                return NoContent();
            }
            catch (ArgumentNullException exception)
            {
                return StatusCode(404, exception.Message);
            }
        }
    }
}
