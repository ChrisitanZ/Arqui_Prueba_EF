namespace Proyecto_Funda_Arqui.Models;

public class ProfesorEstudiante
{
    public int ProfesorId { get; set; }
    public Profesor Profesor { get; set; }
    public int EstudianteId { get; set; }
    public Estudiante Estudiante { get; set; }
}