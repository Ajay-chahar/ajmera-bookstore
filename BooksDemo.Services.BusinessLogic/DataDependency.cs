using BooksDemo.Data.BooksAggregate;
using BooksDemo.Services.BusinessLogic.Book;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace BookStore.Services.BusinessLogic
{
    public static class DataDependency
    {
        public static void RegisterDependecies(IServiceCollection services, IConfiguration configuration)
        {
            InitializeDatabaseHandlers(services, configuration);

            InitializeMappers(services, configuration);

            services.AddScoped<IBookHander, BookHandler>();
        }

        public static void InitializeDatabaseHandlers(IServiceCollection services, IConfiguration configuration)
        {
            BooksDemo.Data.DataDependency.RegisterDependecies(services, configuration);
        }

        public static void InitializeMappers(IServiceCollection services, IConfiguration configuration)
        {
           services.AddAutoMapper(typeof(DataDependency));
        }
    }
}
