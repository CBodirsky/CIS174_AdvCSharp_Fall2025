using MainSite.Data;
using MainSite.Data.Repositories;
using MainSite.Data.Services;
using MainSite.Models;
using MainSite.Views.ToDoList;
using Microsoft.EntityFrameworkCore;

namespace MainSite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register DbContexts first
            builder.Services.AddDbContext<ContactContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ContactContext")));

            builder.Services.AddDbContext<ToDoContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ToDoContext")));

            // Register repositories and services
            builder.Services.AddScoped<IToDoRepository, ToDoRepository>();
            builder.Services.AddScoped<IToDoService, ToDoService>();

            // Other services
            builder.Services.AddMemoryCache();
            builder.Services.AddSession();
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseSession();
            app.UseRouting();
            app.UseAuthorization();

            app.MapStaticAssets();

            app.MapControllerRoute(
                name: "admin",
                pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "customRoute",
                pattern: "custom-path/{controller}/{action}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ContactContext>();
                // context.Database.Migrate();
            }

            app.Run();
        }
    }
}
