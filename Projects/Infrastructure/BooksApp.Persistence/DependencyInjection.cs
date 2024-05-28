using BooksApp.Application.Interfaces.Repositories;
using BooksApp.Persistence.Context.DataBase;
using BooksApp.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BooksApp.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration, string connectionStringName)
        {
            services.AddDbContext<IAppDbContext, AppDbContext>(options => 
                options.UseNpgsql(configuration.GetConnectionString(connectionStringName), 
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            services.InjectRepositories();

            return services;
        } 

        public static void MigrateDataBase(this WebApplication app)
        {
            var serviceScope = app.Services.CreateScope();
            var dataContext = serviceScope.ServiceProvider.GetService<IAppDbContext>();
            dataContext?.MigrateDatabase();
        }
        private static IServiceCollection InjectRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookAuthorsRepository, BookAuthorsRepository>();
            services.AddScoped<IBookGenresRepository, BookGenresRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
