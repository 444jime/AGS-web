using AGS_models;
using AGS_Models;
using Microsoft.EntityFrameworkCore;

// Asegúrate de que los modelos User y Proyecto estén accesibles 
// (puede que necesites un `using AGS_Models;` si están en ese proyecto)

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // Le dices a EF que existe una tabla "Carrusel" que se mapea a la clase "Carrusel"
    public DbSet<Carrusel> Carrusel { get; set; }

    // --- AÑADE ESTAS DOS LÍNEAS ---
    // Le dices a EF que existe una tabla "users" que se mapea a la clase "User"
    public DbSet<User> Usuarios { get; set; }

    // Le dices a EF que existe una tabla "Proyecto" que se mapea a la clase "Proyecto"
    public DbSet<Proyecto> Proyectos { get; set; }
    // -------------------------------


    // Esto es opcional pero MUY RECOMENDADO.
    // Le dice a EF los nombres exactos de las tablas en tu base de datos SQL.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Mapea la clase "User" a la tabla "users" (en minúscula, como en tu SQL)
        modelBuilder.Entity<User>().ToTable("users");

        // Mapea la clase "Proyecto" a la tabla "Proyecto"
        modelBuilder.Entity<Proyecto>().ToTable("Proyecto");

        // Mapea la clase "Carrusel" a la tabla "carrusel"
        modelBuilder.Entity<Carrusel>().ToTable("carrusel");
    }
}