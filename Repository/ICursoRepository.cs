using Proyecto_Funda_Arqui.DTO;

namespace Proyecto_Funda_Arqui.Repository;

public interface ICursoRepository
{
    Task<CursoDTO> GetByIdAsync(int id);
    Task<IEnumerable<CursoDTO>> GetAllAsync();
    Task AddAsync(CursoDTO curso);
    Task UpdateAsync(CursoDTO curso);
    Task DeleteAsync(int id);
}