namespace Proyecto_Funda_Arqui.Models;

public class ProfesorCurso
{
    public int ProfesorId { get; set; }
    public Profesor Profesor { get; set; }
    public int CursoId { get; set; }
    public Curso Curso { get; set; }
}