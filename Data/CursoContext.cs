using Microsoft.EntityFrameworkCore;
using Proyecto_Funda_Arqui.Models;

namespace Proyecto_Funda_Arqui.Data;

public class CursoContext : DbContext
{
    public CursoContext(DbContextOptions<CursoContext> options) : base(options)
    {
    }

    public DbSet<Curso> Cursos { get; set; }
    public DbSet<Profesor> Profesores { get; set; }
    public DbSet<Estudiante> Estudiantes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Curso>()
            .HasMany(c => c.Profesores)
            .WithOne(p => p.Curso)
            .HasForeignKey(p => p.CursoId);

        modelBuilder.Entity<Curso>()
            .HasMany(c => c.Estudiantes)
            .WithOne(e => e.Curso)
            .HasForeignKey(e => e.CursoId);
    }
}