using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TodoList.Business.UserServices;
using TodoList.Domain.Repositories;
using TodoList.Domain.Services;
using TodoList.Infra.Contexts;
using TodoList.Infra.DbMigrations;
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
        }

        public Assembly GetAssemblyInfra()
        {
            return typeof(IMigrationAssembly).Assembly;
        }
    }
}
