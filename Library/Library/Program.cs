using Library.ApplicationServices.Services;
using Library.Core.ServiceInterface;
using Library.Data;
using Library.LINQ;
using Microsoft.EntityFrameworkCore;

namespace Library
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IBookServices, BookServices>();
            builder.Services.AddScoped<ILoanServices, LoanServices>();
            builder.Services.AddScoped<IReaderServices, ReaderServices>();


            // Seadistame andmebaasiühenduse appsettings.json failis oleva ConnectionStrings abil.
            builder.Services.AddDbContext<LibraryContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("LibraryContext")));
            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
