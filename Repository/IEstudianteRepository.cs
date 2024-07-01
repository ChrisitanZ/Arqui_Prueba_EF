using Proyecto_Funda_Arqui.DTO;

namespace Proyecto_Funda_Arqui.Repository;

public interface IEstudianteRepository
{
    Task<EstudianteDTO> GetByIdAsync(int id);
    Task<IEnumerable<EstudianteDTO>> GetAllAsync();
    Task AddAsync(EstudianteDTO estudiante);
    Task UpdateAsync(EstudianteDTO estudiante);
    Task DeleteAsync(int id);
}