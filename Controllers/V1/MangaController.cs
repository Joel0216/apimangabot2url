using Microsoft.AspNetCore.Mvc;
using JaveragesLibrary.Services.Features.Mangas;
using JaveragesLibrary.Domain.Entities;

namespace MiMangaBot.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class MangaController : ControllerBase
    {
        private readonly MangaService _mangaService;

        public MangaController(MangaService mangaService)
        {
            _mangaService = mangaService;
        }

        // GET: api/Manga
        [HttpGet]
        public async Task<ActionResult<List<Manga>>> GetAll()
        {
            var mangas = await _mangaService.GetAllAsync();
            return Ok(mangas);
        }

        // POST: api/Manga
        [HttpPost]
        public async Task<ActionResult<Manga>> Create([FromBody] Manga manga)
        {
            var nuevo = await _mangaService.AddAsync(manga);
            return CreatedAtAction(nameof(GetAll), new { id = nuevo.Id }, nuevo);
        }

        // DELETE: api/Manga/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _mangaService.DeleteAsync(id);
            if (!eliminado) return NotFound();

            return NoContent();
        }
    }
}