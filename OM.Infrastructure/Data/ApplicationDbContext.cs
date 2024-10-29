using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OM.Domain;
using OM.Infrastructure.Identity;
using System.Xml;

namespace OM.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<User, Role, int>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Member> Members { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Member>(entity =>
        {
            entity.ToTable("Member");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(6) without time zone");
            entity.Property(e => e.CreatedBy).HasMaxLength(256);
            entity.Property(e => e.DeleteFlg).HasDefaultValue(false);
            entity.Property(e => e.LastModifiedAt).HasColumnType("timestamp(6) without time zone");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(256);
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.Type)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        builder.Entity<User>(entity =>
        {
            // Maps to the AspNetUsers table
            entity.ToTable("AspNetUsers");

            entity.Property(e => e.FirstName).HasMaxLength(256);
            entity.Property(e => e.LastName).HasMaxLength(256);
        });

        builder.Entity<IdentityUserClaim<int>>(entity =>
        {
            // Maps to the AspNetUserClaims table
            entity.ToTable("AspNetUserClaims");
        });

        builder.Entity<IdentityUserLogin<int>>(entity =>
        {
            // Maps to the AspNetUserLogins table
            entity.ToTable("AspNetUserLogins");
        });

        builder.Entity<IdentityUserToken<int>>(entity =>
        {
            // Maps to the AspNetUserTokens table
            entity.ToTable("AspNetUserTokens");
        });

        builder.Entity<Role>(entity =>
        {
            // Maps to the AspNetRoles table
            entity.ToTable("AspNetRoles");
        });

        builder.Entity<IdentityRoleClaim<int>>(entity =>
        {
            // Maps to the AspNetRoleClaims table
            entity.ToTable("AspNetRoleClaims");
        });

        builder.Entity<IdentityUserRole<int>>(entity =>
        {
            // Maps to the AspNetUserRoles table
            entity.ToTable("AspNetUserRoles");
        });

        // Seed data
        builder.Entity<Role>()
            .HasData(
                new Role
                {
                    Id = 1,
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR",
                    Description = "Administrator",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new Role
                {
                    Id = 2,
                    Name = "User",
                    NormalizedName = "USER",
                    Description = "User",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                });
    }
}
