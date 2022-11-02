using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using Academy.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Academy
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = WebApplication.CreateBuilder(args);
            host.Services.AddCors(options =>
            {
                options.AddPolicy("CORSPolicy",
                    builder =>
                    {
                        builder.AllowAnyMethod().AllowAnyHeader().WithOrigins("https://localhost:3000");
                    });
            });

            var app = host.Build();
            app.UseCors("CORSPolicy");

            using var scope = app.Services.CreateScope();

            await app.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
