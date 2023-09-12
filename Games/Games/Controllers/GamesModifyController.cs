using Games.Data;
using Games.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GamesBlok.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesModifyController : ControllerBase
    {
        private readonly DataContext _context;

        public GamesModifyController(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Добаление игры
        /// </summary>
        /// <param name="game"></param>
        [HttpPost, Route("AddGame")]
        public async Task<ActionResult> PostGameAsync([FromBody] Game game)
        {
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
            return Ok();
        }

        /// <summary>
        /// Удаление игры
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete, Route("Delete")]
        public async Task<ActionResult> DeleteGameAsync([FromQuery] int id)
        {
            var game = await _context.Games.FirstOrDefaultAsync(x => x.Id == id);
            if (game != null)
            {
                _context.Remove(game);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            else
                return NotFound();
        }
    }
}
