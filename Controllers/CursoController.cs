using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Proyecto_Funda_Arqui.DTO;
using Proyecto_Funda_Arqui.Models;
using Proyecto_Funda_Arqui.Services;

[ApiController]
[Route("api/cursos")]
public class CursoController : ControllerBase
{
    private readonly ICursoService _cursoService;

    public CursoController(ICursoService cursoService)
    {
        _cursoService = cursoService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CursoDTO>> GetCurso(int id)
    {
        var curso = await _cursoService.GetCursoByIdAsync(id);
        if (curso == null)
        {
            return NotFound();
        }
        return curso;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CursoDTO>>> GetCursos()
    {
        var cursos = await _cursoService.GetAllCursosAsync();
        return Ok(cursos);
    }

    [HttpPost]
    public async Task<ActionResult> AddCurso(CursoDTO curso)
    {
        await _cursoService.AddCursoAsync(curso);
        return CreatedAtAction(nameof(GetCurso), new { id = curso.Id }, curso);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateCurso(int id, CursoDTO curso)
    {
        

        await _cursoService.UpdateCursoAsync(curso);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCurso(int id)
    {
        await _cursoService.DeleteCursoAsync(id);
        return NoContent();
    }
}
