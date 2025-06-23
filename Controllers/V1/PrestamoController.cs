using JaveragesLibrary.Domain.Entities;
using JaveragesLibrary.Services.Features.Prestamos;
using Microsoft.AspNetCore.Mvc;

namespace MiMangaBot.Controllers.V1
{
    [ApiController]
    [Route("api/v1/prestamos")]
    public class PrestamoController : ControllerBase
    {
        private readonly PrestamoService _prestamoService;

        public PrestamoController(PrestamoService prestamoService)
        {
            _prestamoService = prestamoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var prestamos = await _prestamoService.GetAllAsync(page, pageSize);
            return Ok(prestamos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var prestamo = await _prestamoService.GetByIdAsync(id);
            return prestamo == null ? NotFound() : Ok(prestamo);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Prestamo prestamo)
        {
            await _prestamoService.AddAsync(prestamo);
            return Ok(prestamo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Prestamo prestamo)
        {
            if (id != prestamo.Id) return BadRequest();
            
            await _prestamoService.UpdateAsync(id, prestamo);                                           
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _prestamoService.DeleteAsync(id);
            return NoContent();
        }
    }
}