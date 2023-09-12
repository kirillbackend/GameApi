using Games.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace GamesBlok.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesFiltersController : ControllerBase
    {
        private readonly DataContext _context;

        public GamesFiltersController(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Список всех игр
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("AllGames")]
        public async Task<ActionResult> GetAllGameAsync()
        {
            var games = await _context.Games.ToListAsync();
            if (games.Any())
                return Ok(games);
            else
                return NotFound();
        }

        /// <summary>
        /// Фиильтр по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("Id")]
        public async Task<ActionResult> GetGameIdAsync([FromQuery] int id)
        {
            var game = await _context.Games.FirstOrDefaultAsync(x => x.Id == id);
            if (game == null)
                return NotFound();
            else
                return Ok(game);
        }

        /// <summary>
        /// Фиильтр по названию
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet, Route("Name")]
        public async Task<ActionResult> GetGameNameAsync([FromQuery] string name)
        {
            if (name == null)
                return NotFound();
            else
            {
                var game = await _context.Games.Where(n => n.Name.Contains(name)).ToListAsync();
                return Ok(game);
            }
        }

        /// <summary>
        /// Фиильтр по году релиза
        /// </summary>
        /// <param name="yearRelease"></param>
        /// <returns></returns>
        [HttpGet, Route("YearRelease")]
        public async Task<ActionResult> GetGameYearReleaseAsync([FromQuery] DateTime yearRelease)
        {
            var game = await _context.Games.Where(y => y.YearOfRelease.Year == yearRelease.Year).ToListAsync();
            return Ok(game);
        }

        /// <summary>
        /// Фиильтр по рейтингу
        /// </summary>
        /// <param name="rating"></param>
        /// <returns></returns>
        [HttpGet, Route("Rating")]
        public async Task<ActionResult> GetGameRatingAsync([FromQuery] int rating)
        {
            var game = await _context.Games.Where(r => r.RatingOnMetacritic == rating).ToListAsync();
            return Ok(game);
        }

        /// <summary>
        /// Фиильтр по игровой платформе
        /// </summary>
        /// <param name="platform"></param>
        /// <returns></returns>
        [HttpGet, Route("Platforms")]
        public async Task<ActionResult> GetGamePlatformsAsync([FromQuery] Games.Models.Entities.Game.Platform platform)
        {
            var game = await _context.Games.Where(p => p.Platforms == platform).ToListAsync();
            return Ok(game);
        }

        /// <summary>
        /// Фиильтр по разработчику
        /// </summary>
        /// <param name="developer"></param>
        /// <returns></returns>
        [HttpGet, Route("Developer")]
        public async Task<ActionResult> GetGameDeveloperAsync([FromQuery] string developer)
        {
            var game = await _context.Games.Where(p => p.Developer.Contains(developer)).ToListAsync();
            return Ok(game);
        }

        /// <summary>
        /// Фиильтр по жанру
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        [HttpGet, Route("Genre")]
        public async Task<ActionResult> GetGameGenreAsync([FromQuery] string genre)
        {
            var game = await _context.Games.Where(p => p.Genre.Contains(genre)).ToListAsync();
            return Ok(game);
        }
    }
}
