namespace Proyecto_Funda_Arqui.Models;

public class Profesor
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int CursoId { get; set; }
    public Curso Curso { get; set; }
}
