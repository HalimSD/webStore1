using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApp1.Models.Database
{
    public class WebshopContext : IdentityDbContext<Users>
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ParentChild>()
                .HasKey(bc => new { bc.ChildId, bc.ParentId });
            modelBuilder.Entity<ParentChild>()
                .HasOne(p => p.Child)
                .WithMany(p => p.Children)
                .HasForeignKey(bc => bc.ChildId);
            modelBuilder.Entity<ParentChild>()
                .HasOne(bc => bc.Parent)
                .WithMany(c => c.Parents)
                .HasForeignKey(bc => bc.ParentId);
           
        }
        public WebshopContext(DbContextOptions<WebshopContext> options)
            : base(options)
        {
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<AttributeType> AttributeType { get; set; }
        public DbSet<AttributeValue> AttributeValue { get; set; }
        public DbSet<Favorite> Favorite { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<ParentChild> ParentChild { get; set; }
       

    }

}