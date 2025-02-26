using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductAPI.Entities.Schemas.IdentitySchema;
using ProductAPI.Extensions;

namespace ProductAPI.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users", "Identity");
        builder.HasKey(u => u.Id);
        
        // Name alanı için konfigürasyon
        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(50);
        
        // Surname alanı için konfigürasyon
        builder.Property(u => u.Surname)
            .IsRequired()
            .HasMaxLength(50);
        
        // Username alanı için konfigürasyon
        builder.Property(u => u.Username)
            .IsRequired()
            .HasMaxLength(50);
        builder.HasIndex(u => u.Username)
            .IsUnique();
        
        // Email alanı için konfigürasyon
        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(u => u.Email)
            .IsUnique();
        
        // PasswordHash alanı için konfigürasyon
        builder.Property(u => u.PasswordHash)
            .IsRequired()
            .HasMaxLength(500);
        
        // Role ilişkisi için konfigürasyon
        builder.HasOne(u => u.Role)
            .WithMany()
            .HasForeignKey(u => u.RoleId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.ConfigureAuditableEntity();
    }
}

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles", "Identity");
        builder.HasKey(r => r.Id);
        
        // Name alanı için konfigürasyon
        builder.Property(r => r.Name)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.HasMany(r => r.Users)
            .WithOne(u => u.Role)
            .HasForeignKey(u => u.RoleId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.ConfigureAuditableEntity();
    }
}