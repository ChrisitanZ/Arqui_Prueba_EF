using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Proyecto_Funda_Arqui.DTO;
using Proyecto_Funda_Arqui.Models;
using Proyecto_Funda_Arqui.Services;

[ApiController]
[Route("api/profesores")]
public class ProfesorController : ControllerBase
{
    private readonly IProfesorService _profesorService;

    public ProfesorController(IProfesorService profesorService)
    {
        _profesorService = profesorService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProfesorDTO>> GetProfesor(int id)
    {
        var profesor = await _profesorService.GetProfesorByIdAsync(id);
        if (profesor == null)
        {
            return NotFound();
        }
        return profesor;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProfesorDTO>>> GetProfesores()
    {
        var profesores = await _profesorService.GetAllProfesoresAsync();
        return Ok(profesores);
    }

    [HttpPost]
    public async Task<ActionResult> AddProfesor(ProfesorDTO profesor)
    {
        await _profesorService.AddProfesorAsync(profesor);
        return CreatedAtAction(nameof(GetProfesor), new { id = profesor.Id }, profesor);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateProfesor(int id, ProfesorDTO profesor)
    {
        if (id != profesor.Id)
        {
            return BadRequest();
        }

        await _profesorService.UpdateProfesorAsync(profesor);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProfesor(int id)
    {
        await _profesorService.DeleteProfesorAsync(id);
        return NoContent();
    }
}