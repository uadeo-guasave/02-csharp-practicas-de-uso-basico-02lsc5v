using Microsoft.EntityFrameworkCore;

namespace _02_csharp_primeros_pasos.Models
{
  public class VespertinoDbContext : DbContext
  {
    // Definir los conjuntos de datos
    public DbSet<Role> Roles { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<User> Users { get; set; }

    // Configurar la conexión
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("Data Source=Db/vespertino.db");
      base.OnConfiguring(optionsBuilder);
    }

    // Configurar el modelo de datos
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // definir todas las características de las tablas y sus columnas
      modelBuilder.Entity<Role>(role =>
      {
        role.Property(r => r.Id).HasColumnName("id");
        role.Property(r => r.Name).HasColumnName("name");
        role.Property(r => r.Description).HasColumnName("description");
        role.Property(r => r.Level).HasColumnName("level");
        
      });

      base.OnModelCreating(modelBuilder);
    }
  }
}