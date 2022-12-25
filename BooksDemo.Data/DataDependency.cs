using BooksDemo.Data.BooksAggregate;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BooksDemo.Data
{
    public static class DataDependency
    {
        public static void RegisterDependecies(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBookRepository, BookRepository>();
        }
    }
}
