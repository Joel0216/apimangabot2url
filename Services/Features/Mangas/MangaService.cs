using JaveragesLibrary.Data;
using JaveragesLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JaveragesLibrary.Services.Features.Mangas
{
    public class MangaService
    {
        private readonly MangaDbContext _context;

        public MangaService(MangaDbContext context)
        {
            _context = context;
        }

        // Obtener todos los mangas
        public async Task<List<Manga>> GetAllAsync()
        {
            return await _context.Mangas.ToListAsync();
        }

        // Agregar nuevo manga
        public async Task<Manga> AddAsync(Manga manga)
        {
            var nuevo = new Manga
            {
                Titulo = manga.Titulo,
                Autor = manga.Autor,
                Capitulos = manga.Capitulos
            };

            _context.Mangas.Add(nuevo);
            await _context.SaveChangesAsync();

            return nuevo;
        }

        // Eliminar manga por ID
        public async Task<bool> DeleteAsync(int id)
        {
            var manga = await _context.Mangas.FindAsync(id);
            if (manga == null) return false;

            _context.Mangas.Remove(manga);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}