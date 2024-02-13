using Microsoft.EntityFrameworkCore;
using ProjetoUppercase.Models;

namespace ProjetoUppercase
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<Context>
                (options => options.UseSqlServer("Server=.\\MSSQLSERVER01;Initial Catalog=ProjetoUppercase;Trusted_Connection=True;TrustServerCertificate=True"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Carros/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Carros}/{action=Index}/{id?}");

            app.Run();
        }
    }
}