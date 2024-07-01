namespace Proyecto_Funda_Arqui.Models;

public class Curso
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public ICollection<Profesor> Profesores { get; set; }
    public ICollection<Estudiante> Estudiantes { get; set; }
}