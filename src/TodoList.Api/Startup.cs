using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TodoList.DependencyInjection;

namespace TodoList.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddResponseCompression();
            ResolveDependency(services);
            ConfigureFluentMigrator(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IMigrationRunner migrationRunner)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();
            migrationRunner.MigrateUp();
        }

        private void ResolveDependency(IServiceCollection services)
        {
            new DependencyResolver().Resolver(services);
            //services.AddTransient<ITokenService, TokenService>();
        }

        private void ConfigureFluentMigrator(IServiceCollection services)
        {
            var assemblyInfra = new DependencyResolver().GetAssemblyInfra();

            services.AddFluentMigratorCore()
                .ConfigureRunner(
                builder => builder
               .AddSqlServer()
               .WithGlobalConnectionString(Configuration["ConnStrSqlServer"])
               .ScanIn(assemblyInfra).For.Migrations());
        }
    }
}
