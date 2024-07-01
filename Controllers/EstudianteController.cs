using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Proyecto_Funda_Arqui.DTO;
using Proyecto_Funda_Arqui.Models;
using Proyecto_Funda_Arqui.Services;

[ApiController]
[Route("api/estudiantes")]
public class EstudianteController : ControllerBase
{
    private readonly IEstudianteService _estudianteService;

    public EstudianteController(IEstudianteService estudianteService)
    {
        _estudianteService = estudianteService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EstudianteDTO>> GetEstudiante(int id)
    {
        var estudiante = await _estudianteService.GetEstudianteByIdAsync(id);
        if (estudiante == null)
        {
            return NotFound();
        }
        return estudiante;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EstudianteDTO>>> GetEstudiantes()
    {
        var estudiantes = await _estudianteService.GetAllEstudiantesAsync();
        return Ok(estudiantes);
    }

    [HttpPost]
    public async Task<ActionResult> AddEstudiante(EstudianteDTO estudiante)
    {
        await _estudianteService.AddEstudianteAsync(estudiante);
        return CreatedAtAction(nameof(GetEstudiante), new { id = estudiante.Id }, estudiante);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateEstudiante(int id, EstudianteDTO estudiante)
    {
        if (id != estudiante.Id)
        {
            return BadRequest();
        }

        await _estudianteService.UpdateEstudianteAsync(estudiante);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteEstudiante(int id)
    {
        await _estudianteService.DeleteEstudianteAsync(id);
        return NoContent();
    }
}
