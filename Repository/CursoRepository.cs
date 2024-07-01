using Microsoft.EntityFrameworkCore;
using Proyecto_Funda_Arqui.Data;
using Proyecto_Funda_Arqui.DTO;
using Proyecto_Funda_Arqui.Models;

namespace Proyecto_Funda_Arqui.Repository;

public class CursoRepository : ICursoRepository
{
    private readonly CursoContext _context;

    public CursoRepository(CursoContext context)
    {
        _context = context;
    }

    public async Task<CursoDTO> GetByIdAsync(int id)
    {
        var curso = await _context.Cursos
            .AsNoTracking()
            .Where(c => c.Id == id)
            .Select(c => new CursoDTO
            {
                Id = c.Id,
                Nombre = c.Nombre
            })
            .FirstOrDefaultAsync();

        return curso;
    }

    public async Task<IEnumerable<CursoDTO>> GetAllAsync()
    {
        var cursos = await _context.Cursos
            .AsNoTracking()
            .Select(c => new CursoDTO
            {
                Id = c.Id,
                Nombre = c.Nombre
            })
            .ToListAsync();

        return cursos;
    }

    public async Task AddAsync(CursoDTO curso)
    {
        var cursoToAdd = new Curso
        {
            Nombre = curso.Nombre
        };

        _context.Cursos.Add(cursoToAdd);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(CursoDTO curso)
    {
        var cursoToUpdate = await _context.Cursos.FindAsync(curso.Id);
        if (cursoToUpdate != null)
        {
            cursoToUpdate.Nombre = curso.Nombre;
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var cursoToDelete = await _context.Cursos.FindAsync(id);
        if (cursoToDelete != null)
        {
            _context.Cursos.Remove(cursoToDelete);
            await _context.SaveChangesAsync();
        }
    }
}