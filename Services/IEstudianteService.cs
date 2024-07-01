using Proyecto_Funda_Arqui.DTO;
using Proyecto_Funda_Arqui.Models;

namespace Proyecto_Funda_Arqui.Services;

public interface IEstudianteService
{
    Task<EstudianteDTO> GetEstudianteByIdAsync(int id);
    Task<IEnumerable<EstudianteDTO>> GetAllEstudiantesAsync();
    Task AddEstudianteAsync(EstudianteDTO estudiante);
    Task UpdateEstudianteAsync(EstudianteDTO estudiante);
    Task DeleteEstudianteAsync(int id);
}