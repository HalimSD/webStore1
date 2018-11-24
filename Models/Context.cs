using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp1.products;

namespace WebApp1.Models
{
    public class WebshopContext : IdentityDbContext<Users>
    {
        public WebshopContext (DbContextOptions<WebshopContext> options)
            : base(options)
        {
        }
        
        public DbSet<Products> Products { get; set; }
        public DbSet<Extra_Atributes> Extra_Atributes {get; set;}
        public DbSet<Productsoort> Productsoort {get; set;}
        public DbSet<Productwaarde> Productwaarde {get; set;}
        public DbSet<Attribuutsoort> Attribuutsoort {get; set;}
        public DbSet<Attribuutwaarde> Attribuutwaarde {get; set;}
        public DbSet<FavoritesModel> Favorites { get; set; }
        public DbSet<Item> Items { get; set; }


    }
}