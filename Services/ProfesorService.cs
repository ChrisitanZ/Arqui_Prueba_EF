using Proyecto_Funda_Arqui.Data;
using Proyecto_Funda_Arqui.DTO;
using Proyecto_Funda_Arqui.Models;
using Proyecto_Funda_Arqui.Repository;

namespace Proyecto_Funda_Arqui.Services;

public class ProfesorService : IProfesorService
{
    private readonly IProfesorRepository _profesorRepository;

    public ProfesorService(IProfesorRepository profesorRepository)
    {
        _profesorRepository = profesorRepository;
    }

    public async Task<ProfesorDTO> GetProfesorByIdAsync(int id)
    {
        return await _profesorRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<ProfesorDTO>> GetAllProfesoresAsync()
    {
        return await _profesorRepository.GetAllAsync();
    }

    public async Task AddProfesorAsync(ProfesorDTO profesor)
    {
        await _profesorRepository.AddAsync(profesor);
    }

    public async Task UpdateProfesorAsync(ProfesorDTO profesor)
    {
        await _profesorRepository.UpdateAsync(profesor);
    }

    public async Task DeleteProfesorAsync(int id)
    {
        await _profesorRepository.DeleteAsync(id);
    }
}