using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Common;
using TodoList.DependencyInjection;
using TodoList.FluentMigrations.DbMigrations;

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
            Runtime.ConnectionStringSqlServer = Configuration["ConnStrSqlServer"];
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IMigrationRunner migrationRunner)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();
            app.UseResponseCompression();
            migrationRunner.MigrateUp();
        }

        private void ResolveDependency(IServiceCollection services)
        {
            new DependencyResolver().Resolver(services);
            //services.AddTransient<ITokenService, TokenService>();
        }

        private void ConfigureFluentMigrator(IServiceCollection services)
        {
            services.AddFluentMigratorCore()
                .ConfigureRunner(
                builder => builder
                .WithVersionTable(new TableVersionMigration())
                .AddSqlServer()
                .WithGlobalConnectionString(Configuration["ConnStrSqlServer"])
                .ScanIn(typeof(TableVersionMigration).Assembly).For.Migrations());
        }
    }
}
