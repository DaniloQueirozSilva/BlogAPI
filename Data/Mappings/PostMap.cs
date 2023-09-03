using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BlogEF.Data.Mappings
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            //Tabela
            builder.ToTable("Post");

            builder.HasKey(c => c.Id);

            //Identity
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(); //PRIMARY KEY IDENTITY (1, 1)

            //Propriedades
            builder.Property(x => x.LastUpdateDate)
                .IsRequired()
                .HasColumnName("LastUpdateDate")
                .HasColumnType("SMALLDATETIME")                
                .HasDefaultValueSql("GETDATE()");

            // Indices
            builder.HasIndex(x => x.Slug, "IX_Post_Slug")
                .IsUnique();

            //Relacionamentos
            builder.HasOne(x => x.Author)
                .WithMany(x=>x.Posts)
                .HasConstraintName("FK_Post_Author")
                //Atenção no DeleteBahavior
                .OnDelete(DeleteBehavior.Cascade);
           

            builder.
                HasOne(x => x.Category)
               .WithMany(x => x.Posts)
               .HasConstraintName("FK_Post_Category")
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Tags)
                .WithMany(x => x.Posts)
                .UsingEntity<Dictionary<string, object>>(
                    "PostTag",
                        post => post
                        .HasOne<Tag>()
                        .WithMany()
                        .HasForeignKey("PostId")
                        .HasConstraintName("FK_PostRole_PostId")
                        .OnDelete(DeleteBehavior.Cascade),
                    tag => tag
                        .HasOne<Post>()
                        .WithMany()
                        .HasForeignKey("TagId")
                        .HasConstraintName("FK_PostTag_TagId")
                        .OnDelete(DeleteBehavior.Cascade));

        }
    }
}
