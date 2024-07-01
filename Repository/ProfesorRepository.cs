using Microsoft.EntityFrameworkCore;
using Proyecto_Funda_Arqui.Data;
using Proyecto_Funda_Arqui.DTO;
using Proyecto_Funda_Arqui.Models;

namespace Proyecto_Funda_Arqui.Repository;

public class ProfesorRepository : IProfesorRepository
{
    private readonly CursoContext _context;

    public ProfesorRepository(CursoContext context)
    {
        _context = context;
    }

    public async Task<ProfesorDTO> GetByIdAsync(int id)
    {
        var profesor = await _context.Profesores
            .AsNoTracking()
            .Where(p => p.Id == id)
            .Select(p => new ProfesorDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                CursoId = p.CursoId
            })
            .FirstOrDefaultAsync();

        return profesor;
    }

    public async Task<IEnumerable<ProfesorDTO>> GetAllAsync()
    {
        var profesores = await _context.Profesores
            .AsNoTracking()
            .Select(p => new ProfesorDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                CursoId = p.CursoId
            })
            .ToListAsync();

        return profesores;
    }

    public async Task AddAsync(ProfesorDTO profesor)
    {
        var profesorToAdd = new Profesor
        {
            Nombre = profesor.Nombre,
            CursoId = profesor.CursoId
        };

        _context.Profesores.Add(profesorToAdd);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ProfesorDTO profesor)
    {
        var profesorToUpdate = await _context.Profesores.FindAsync(profesor.Id);
        if (profesorToUpdate != null)
        {
            profesorToUpdate.Nombre = profesor.Nombre;
            profesorToUpdate.CursoId = profesor.CursoId;
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var profesorToDelete = await _context.Profesores.FindAsync(id);
        if (profesorToDelete != null)
        {
            _context.Profesores.Remove(profesorToDelete);
            await _context.SaveChangesAsync();
        }
    }
}