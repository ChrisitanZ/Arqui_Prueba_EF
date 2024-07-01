using Proyecto_Funda_Arqui.DTO;
using Proyecto_Funda_Arqui.Models;

namespace Proyecto_Funda_Arqui.Services;

public interface ICursoService
{
    Task<CursoDTO> GetCursoByIdAsync(int id);
    Task<IEnumerable<CursoDTO>> GetAllCursosAsync();
    Task AddCursoAsync(CursoDTO curso);
    Task UpdateCursoAsync(CursoDTO curso);
    Task DeleteCursoAsync(int id);
}