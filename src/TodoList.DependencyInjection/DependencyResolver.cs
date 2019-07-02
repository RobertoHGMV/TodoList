using FluentMigrator.Runner.VersionTableInfo;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Business.UserServices;
using TodoList.Domain.Repositories;
using TodoList.Domain.Services;
using TodoList.FluentMigrations.DbMigrations;
using TodoList.Infra.Contexts;
using TodoList.Infra.Repositories;
using TodoList.Infra.Transactions;

namespace TodoList.DependencyInjection
{
    public class DependencyResolver
    {
        public void Resolver(IServiceCollection services)
        {
            services.AddScoped<TodoListDataContext, TodoListDataContext>();
            services.AddTransient<IUow, Uow>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IVersionTableMetaData, TableVersionMigration>();
        }
    }
}
