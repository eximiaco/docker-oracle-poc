using docker_oracle_poc.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Oracle.ManagedDataAccess.Client;
using System.Threading;

namespace docker_oracle_poc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            Migrate(host);
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });

        private static void Migrate(IHost host)
        {
            while (true)
            {
                try
                {
                    using (var scope = host.Services.CreateScope())
                    {
                        var db = scope.ServiceProvider.GetRequiredService<DataContext>();
                        db.Database.Migrate();
                    }

                    return;

                }
                catch (OracleException ex)
                {
                    if (ex.Number != 12514 && ex.Number != 12528)
                        throw;

                    Thread.Sleep(10000);
                }
            }


        }
    }
}