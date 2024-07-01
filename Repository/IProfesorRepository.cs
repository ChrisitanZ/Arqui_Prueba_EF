using Proyecto_Funda_Arqui.DTO;

namespace Proyecto_Funda_Arqui.Repository;

public interface IProfesorRepository
{
    Task<ProfesorDTO> GetByIdAsync(int id);
    Task<IEnumerable<ProfesorDTO>> GetAllAsync();
    Task AddAsync(ProfesorDTO profesor);
    Task UpdateAsync(ProfesorDTO profesor);
    Task DeleteAsync(int id);
}