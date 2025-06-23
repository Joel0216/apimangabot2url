using JaveragesLibrary.Domain.Entities;
using JaveragesLibrary.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaveragesLibrary.Services.Features.Prestamos
{
    public class PrestamoService
    {
        private readonly MangaDbContext _context;

        public PrestamoService(MangaDbContext context)
        {
            _context = context;
        }

        public async Task<Prestamo?> GetByIdAsync(int id)
        {
            return await _context.Prestamos.FindAsync(id);
        }

        public async Task<Prestamo> AddAsync(Prestamo prestamo)
        {
            // Validar que el MangaId exista
            var manga = await _context.Mangas.FindAsync(prestamo.MangaId);
            if (manga == null)
                throw new ArgumentException("El MangaId proporcionado no existe.");

            // Validar que el NombreCliente no esté vacío
            if (string.IsNullOrWhiteSpace(prestamo.NombreCliente))
                throw new ArgumentException("El NombreCliente no puede estar vacío.");

            _context.Prestamos.Add(prestamo);
            await _context.SaveChangesAsync();
            return prestamo;
        }

        public async Task<Prestamo?> UpdateAsync(int id, Prestamo prestamo)
        {
            var existing = await _context.Prestamos.FindAsync(id);
            if (existing == null)
                return null;

            existing.NombreCliente = prestamo.NombreCliente;
            existing.MangaId = prestamo.MangaId;
            existing.FechaPrestamo = prestamo.FechaPrestamo;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var prestamo = await _context.Prestamos.FindAsync(id);
            if (prestamo == null)
                return false;

            _context.Prestamos.Remove(prestamo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Prestamo>> GetAllAsync(int page = 1, int pageSize = 10)
        {
            return await _context.Prestamos
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}