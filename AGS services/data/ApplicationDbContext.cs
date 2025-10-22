using AGS_models;
using Microsoft.EntityFrameworkCore;



public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    
    public DbSet<Carrusel> Carrusel { get; set; }
}