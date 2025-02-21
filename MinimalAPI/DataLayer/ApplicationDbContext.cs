using Microsoft.EntityFrameworkCore;

namespace MinimalAPI.DataLayer;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Rol> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Usuario>().ToTable("Usuario");

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.ToTable("ROL"); // Asigna un nombre diferente a la tabla

            entity.HasKey(u => u.RolId); // Define la clave primaria

            entity.Property(u => u.RolId)
                  .HasColumnName("ROL_ID") // Cambia el nombre de la columna
                  .IsRequired();

            entity.Property(u => u.Nombre)
                  .HasColumnName("NOMBRE") // Cambia el nombre de la columna
                  .HasMaxLength(50) // Longitud máxima
                  .IsRequired(); // Obligatorio           
        });
    }
}
