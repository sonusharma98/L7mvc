using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//tinfo200:[2020 - 03 - 12 - sonu - dykstra1]- added using statement in order to reach subdirectiory for DbInitializer adn SchoolContext
using ContosoUniversity.Data;
using Microsoft.Extensions.DependencyInjection;
namespace ContosoUniversity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            //tinfo200:[2020 - 03 - 12 - sonu - dykstra1]- seperates call to build and call to run whether there is Db or not
            var host = CreateHostBuilder(args).Build();

            CreateDbIfNotExists(host);

            host.Run();

        }

        //tinfo200:[2020 - 03 - 12 - sonu - dykstra1]- if datatbase doesnt exists it calls the initializer class
        private static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<SchoolContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
