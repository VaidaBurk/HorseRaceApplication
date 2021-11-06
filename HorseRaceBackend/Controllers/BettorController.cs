using HorseRaceBackend.Dtos;
using HorseRaceBackend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HorseRaceBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BettorController : Controller
    {
        private readonly BettorService _bettorService;

        public BettorController(BettorService bettorService)
        {
            _bettorService = bettorService;
        }

        [HttpGet]
        public async Task<ActionResult> GetBettors()
        {
            return Ok(await _bettorService.GetBettorsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetBettor(int id)
        {
            return Ok(await _bettorService.GetBettorAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddBettor(BettorAddDto newBettor)
        {
            return Ok(await _bettorService.AddBettorAsync(newBettor));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBettor(BettorUpdateDto updatedBettor)
        {
            return Ok(await _bettorService.UpdateBettorAsync(updatedBettor));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBettor(int id)
        {
            await _bettorService.RemoveBettorAsync(id);
            return NoContent();
        }

        [HttpGet("Horse/{id}")]
        public async Task<ActionResult> FilterByHorseId(int id)
        {
            return Ok(await _bettorService.FilterByHorseId(id));
        }
    }
}
