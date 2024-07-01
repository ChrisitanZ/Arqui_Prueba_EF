using Microsoft.EntityFrameworkCore;
using Proyecto_Funda_Arqui.Data;
using Proyecto_Funda_Arqui.DTO;
using Proyecto_Funda_Arqui.Models;
using Proyecto_Funda_Arqui.Repository;

namespace Proyecto_Funda_Arqui.Services;

public class CursoService : ICursoService
{
    private readonly ICursoRepository _cursoRepository;

    public CursoService(ICursoRepository cursoRepository)
    {
        _cursoRepository = cursoRepository;
    }

    public async Task<CursoDTO> GetCursoByIdAsync(int id)
    {
        return await _cursoRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<CursoDTO>> GetAllCursosAsync()
    {
        return await _cursoRepository.GetAllAsync();
    }

    public async Task AddCursoAsync(CursoDTO curso)
    {
        await _cursoRepository.AddAsync(curso);
    }

    public async Task UpdateCursoAsync(CursoDTO curso)
    {
        await _cursoRepository.UpdateAsync(curso);
    }

    public async Task DeleteCursoAsync(int id)
    {
        await _cursoRepository.DeleteAsync(id);
    }
}