using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp1.Models;

namespace WebApp1.Models
{
    public class WebshopContext : IdentityDbContext<Users>
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<WebApp1.Models.ParentChild>()
                .HasKey(bc => new { bc.ChildId, bc.ParentId });
            modelBuilder.Entity<WebApp1.Models.ParentChild>()
                .HasOne(p => p.Child)
                .WithMany(p => p.Children)
                .HasForeignKey(bc => bc.ChildId);
            modelBuilder.Entity<WebApp1.Models.ParentChild>()
                .HasOne(bc => bc.Parent)
                .WithMany(c => c.Parents)
                .HasForeignKey(bc => bc.ParentId);
        }  
        public WebshopContext(DbContextOptions<WebshopContext> options)
            : base(options)
        {
        }
        public DbSet<Extra_Atributes> Extra_Atributes { get; set; }
        public DbSet<Productsoort> Productsoort { get; set; }
        public DbSet<Productwaarde> Productwaarde { get; set; }
        public DbSet<Attribuutsoort> Attribuutsoort { get; set; }
        public DbSet<Attribuutwaarde> Attribuutwaarde { get; set; }
        public DbSet<FavoritesModel> Favorites { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<BesteldeItem> BesteldeItem { get; set; }
        public DbSet<Bestelling> Bestelling { get; set; }
        public DbSet<ParentChild> ParentChild { get; set; }

    }

}