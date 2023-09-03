
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogEF.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //Tabela
            builder.ToTable("Category");

            //Chave Primária
            builder.HasKey(c => c.Id);
            
            //Identity
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(); //PRIMARY KEY IDENTITY (1, 1)


            //Propriedades
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.Slug)
                .IsRequired()
                .HasColumnName("Slug")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);

            // Indices
            builder.HasIndex(x => x.Slug, "IX_Category_Slug")
                .IsUnique();
                
        }
    }
}
