using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace BlogEF.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //Tabela
            builder.ToTable("User");

            //Chave Primária
            builder.HasKey(c => c.Id);

            //Identity
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(); //PRIMARY KEY IDENTITY (1, 1)

            builder.Property(c => c.Bio);
            builder.Property(c => c.Email);
            builder.Property(c => c.Image);
            builder.Property(c => c.PasswordHash);
            builder.Property(c => c.GitHub);

            builder.Property(x => x.Slug)
           .IsRequired()
           .HasColumnName("Slug")
           .HasColumnType("NVARCHAR")
           .HasMaxLength(80);

            builder.HasIndex(x => x.Slug, "IX_User_Slug")
                .IsUnique();

            builder.HasMany(x => x.Roles)
                .WithMany(x => x.Users)
                .UsingEntity<Dictionary<string, object>>(
            "UserRole",
            role => role.HasOne<Role>()
              .WithMany()
              .HasForeignKey("RoleId")
              .HasConstraintName("FK_UserRole_RoleId")
              .OnDelete(DeleteBehavior.Cascade),
            user => user.HasOne<User>()
              .WithMany()
              .HasForeignKey("UserId")
              .HasConstraintName("FK_UserRole_UserId")
              .OnDelete(DeleteBehavior.Cascade));

        }
    }
}
