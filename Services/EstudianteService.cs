using Microsoft.EntityFrameworkCore;
using Proyecto_Funda_Arqui.Data;
using Proyecto_Funda_Arqui.DTO;
using Proyecto_Funda_Arqui.Models;
using Proyecto_Funda_Arqui.Repository;

namespace Proyecto_Funda_Arqui.Services;

public class EstudianteService : IEstudianteService
{
    private readonly IEstudianteRepository _estudianteRepository;

    public EstudianteService(IEstudianteRepository estudianteRepository)
    {
        _estudianteRepository = estudianteRepository;
    }

    public async Task<EstudianteDTO> GetEstudianteByIdAsync(int id)
    {
        return await _estudianteRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<EstudianteDTO>> GetAllEstudiantesAsync()
    {
        return await _estudianteRepository.GetAllAsync();
    }

    public async Task AddEstudianteAsync(EstudianteDTO estudiante)
    {
        await _estudianteRepository.AddAsync(estudiante);
    }

    public async Task UpdateEstudianteAsync(EstudianteDTO estudiante)
    {
        await _estudianteRepository.UpdateAsync(estudiante);
    }

    public async Task DeleteEstudianteAsync(int id)
    {
        await _estudianteRepository.DeleteAsync(id);
    }
}