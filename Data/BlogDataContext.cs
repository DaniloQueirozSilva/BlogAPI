using Blog.Models;
using BlogEF.Data.Mappings;
using BlogEF.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Security;

namespace Blog.Data
{
    public class BlogDataContext : DbContext
    {
     
     
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }             
        public DbSet<User> Users { get; set; }
  



        protected override void OnConfiguring(DbContextOptionsBuilder options)
        =>  options.UseSqlServer("TrustServerCertificate=True;Persist Security Info=False;Integrated Security=true;Initial Catalog=Blog;server=DESKTOP-CNEN69R");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new PostMap());
        }


    }
}
