using Microsoft.EntityFrameworkCore;
using Proyecto_Funda_Arqui.Data;
using Proyecto_Funda_Arqui.DTO;
using Proyecto_Funda_Arqui.Models;

namespace Proyecto_Funda_Arqui.Repository;

public class EstudianteRepository : IEstudianteRepository
{
    private readonly CursoContext _context;

    public EstudianteRepository(CursoContext context)
    {
        _context = context;
    }

    public async Task<EstudianteDTO> GetByIdAsync(int id)
    {
        var estudiante = await _context.Estudiantes
            .AsNoTracking()
            .Where(e => e.Id == id)
            .Select(e => new EstudianteDTO
            {
                Id = e.Id,
                Nombre = e.Nombre,
                CursoId = e.CursoId
            })
            .FirstOrDefaultAsync();

        return estudiante;
    }

    public async Task<IEnumerable<EstudianteDTO>> GetAllAsync()
    {
        var estudiantes = await _context.Estudiantes
            .AsNoTracking()
            .Select(e => new EstudianteDTO
            {
                Id = e.Id,
                Nombre = e.Nombre,
                CursoId = e.CursoId
            })
            .ToListAsync();

        return estudiantes;
    }

    public async Task AddAsync(EstudianteDTO estudiante)
    {
        var estudianteToAdd = new Estudiante
        {
            Nombre = estudiante.Nombre,
            CursoId = estudiante.CursoId
        };

        _context.Estudiantes.Add(estudianteToAdd);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(EstudianteDTO estudiante)
    {
        var estudianteToUpdate = await _context.Estudiantes.FindAsync(estudiante.Id);
        if (estudianteToUpdate != null)
        {
            estudianteToUpdate.Nombre = estudiante.Nombre;
            estudianteToUpdate.CursoId = estudiante.CursoId;
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var estudianteToDelete = await _context.Estudiantes.FindAsync(id);
        if (estudianteToDelete != null)
        {
            _context.Estudiantes.Remove(estudianteToDelete);
            await _context.SaveChangesAsync();
        }
    }
}