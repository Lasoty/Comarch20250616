using Bibliotekarz.Client.Pages;
using Bibliotekarz.Components;
using Bibliotekarz.Context;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

namespace Bibliotekarz
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Konfiguracja AppDbContext (dostêp do bazy danych)
            builder.Services.AddDbContext<AppDbContext>(options
                => options.UseSqlServer(
                      builder.Configuration.GetConnectionString("DefaultConnection")
                    ).EnableSensitiveDataLogging().EnableDetailedErrors()
                );

            // Add MudBlazor services
            builder.Services.AddMudServices();

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveWebAssemblyComponents();

            builder.Services.AddControllers();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAntiforgery();

            app.MapStaticAssets();

            app.MapControllers();
            app.MapRazorComponents<App>()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);
            
            app.Run();
        }
    }
}
