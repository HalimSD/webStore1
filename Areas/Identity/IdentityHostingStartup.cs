// using Microsoft.AspNetCore.Hosting;
// using WebApp1.Models;

// public class IdentityHostingStartup : IHostingStartup
// {
//     public void Configure(IWebHostBuilder builder)
//     {
//         builder.ConfigureServices((context, services) => {
//             services.AddDbContext<WebshopContext>(options =>
//                 options.UseNpgsql(@"Host=localhost;Database=webShop;Username=postgres;Password=1.Halimsd"));

//             services.AddDefaultIdentity<Users>(config =>
//                 {
//                     config.SignIn.RequireConfirmedEmail = true;
//                 })
//                 .AddEntityFrameworkStores<WebshopContext>();
//         });
//     }
// }