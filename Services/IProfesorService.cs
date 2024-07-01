using Proyecto_Funda_Arqui.DTO;
using Proyecto_Funda_Arqui.Models;

namespace Proyecto_Funda_Arqui.Services;

public interface IProfesorService
{
    Task<ProfesorDTO> GetProfesorByIdAsync(int id);
    Task<IEnumerable<ProfesorDTO>> GetAllProfesoresAsync();
    Task AddProfesorAsync(ProfesorDTO profesor);
    Task UpdateProfesorAsync(ProfesorDTO profesor);
    Task DeleteProfesorAsync(int id);
}