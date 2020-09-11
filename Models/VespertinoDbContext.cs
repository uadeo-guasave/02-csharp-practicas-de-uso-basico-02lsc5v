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

        role.HasIndex(r => r.Name).IsUnique();

        // Relaciones
        role.HasMany(r => r.Users)
          .WithOne(u => u.Role);

        role.HasMany(r => r.RolesHasPermissions)
          .WithOne(rh => rh.Role);
      });

      modelBuilder.Entity<Permission>(perm =>
      {
        perm.Property(p => p.Id).HasColumnName("id");
        perm.Property(p => p.Name).HasColumnName("name");
        perm.Property(p => p.Description).HasColumnName("description");

        perm.HasIndex(p => p.Name).IsUnique();

        // Relaciones
        perm.HasMany(p => p.RolesHasPermissions)
          .WithOne(rh => rh.Permission);
      });

      modelBuilder.Entity<RoleHasPermission>(rhp =>
      {
        rhp.Property(r => r.RoleId).HasColumnName("role_id");
        rhp.Property(r => r.PermissionId).HasColumnName("permission_id");

        rhp.HasKey(r => new { r.RoleId, r.PermissionId });

        // Relaciones FK
        rhp.HasOne(rh => rh.Role)
          .WithMany(r => r.RolesHasPermissions)
          .HasForeignKey(rh => rh.RoleId);
        
        rhp.HasOne(rh => rh.Permission)
          .WithMany(p => p.RolesHasPermissions)
          .HasForeignKey(rh => rh.PermissionId);
      });

      modelBuilder.Entity<User>(user =>
      {
        user.Property(u => u.Id).HasColumnName("id");
        user.Property(u => u.Name).HasColumnName("name");
        user.Property(u => u.Password).HasColumnName("password");
        user.Property(u => u.Firstname).HasColumnName("firstname");
        user.Property(u => u.Lastname).HasColumnName("lastname");
        user.Property(u => u.Email).HasColumnName("email");
        user.Property(u => u.RememberToken).HasColumnName("remember_token");
        user.Property(u => u.Gender).HasColumnName("gender");
        user.Property(u => u.RoleId).HasColumnName("role_id");

        user.HasIndex(u => u.Name).IsUnique();
        user.HasIndex(u => u.Email).IsUnique();

        // Relaciones FK
        user.HasOne(u => u.Role)
          .WithMany(r => r.Users)
          .HasForeignKey(u => u.RoleId);
      });

      base.OnModelCreating(modelBuilder);
    }
  }
}