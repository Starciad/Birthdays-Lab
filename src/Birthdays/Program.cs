using Birthdays.Database;

using Microsoft.EntityFrameworkCore;

namespace Birthdays
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<BirthdaysDbContext>(options =>
            {
                options.UseSqlite("Data Source=birthdays.db");
            });

            WebApplication app = builder.Build();

#if DEBUG
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
#endif

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}"
            );

            await app.RunAsync();
        }
    }
}