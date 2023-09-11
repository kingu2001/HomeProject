using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DependencyInjectionTest.Data;
using DependencyInjectionTest.Models;
using Microsoft.AspNetCore.Http;

namespace DependencyInjectionTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<DependencyInjectionTestContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DependencyInjectionTestContext") ?? throw new InvalidOperationException("Connection string 'DependencyInjectionTestContext' not found.")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            /*
             * Den tager det nederste. Man kan skelne med if statements. 
             */
            builder.Services.AddScoped<IDummy, Dummy>();

            var app = builder.Build();
            //Middleware 1
            app.Run(async (HttpContext context) => { await context.Response.WriteAsync("Welcome"); });
            

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}