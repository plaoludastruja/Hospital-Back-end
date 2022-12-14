﻿using System;
using System.Linq;
using IntegrationAPI;
using IntegrationLibrary.Settings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TestIntegrationApp.Setup
{
    public class TestDatabaseFactory<TStartUp> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseSolutionRelativeContentRoot("");

            builder.ConfigureServices(services =>
            {
                using IServiceScope scope = BuildServiceProvider(services).CreateScope();
                IServiceProvider scopedServices = scope.ServiceProvider;
                IntegrationDbContext db = scopedServices.GetRequiredService<IntegrationDbContext>();

                InitializeDatabase(db);
            });
        }

        private static ServiceProvider BuildServiceProvider(IServiceCollection services)
        {
            ServiceDescriptor descriptor =
                services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<IntegrationDbContext>));
            services.Remove(descriptor);

            services.AddDbContext<IntegrationDbContext>(opt => opt.UseNpgsql(CreateConnectionStringForTest()));
            return services.BuildServiceProvider();
        }

        private static string CreateConnectionStringForTest()
        {
            return "Host=localhost;Database=IntegrationTestDb;Username=postgres;Password=password;";
        }

        private static void InitializeDatabase(IntegrationDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.Database.ExecuteSqlRaw(
                "INSERT INTO public.blood_banks(\r\n\t\"Id\", \"Name\", \"ServerAddress\", \"EmailAddress\", \"Password\", \"ApiKey\")\r\n\tVALUES ('37ae7862-f847-4a39-b39f-f8ff31452b5e', 'Bankica', 'localhost', 'isaproject202223@gmail.com', 'password', 'apikey');");

            context.SaveChanges();
        }
    }
}