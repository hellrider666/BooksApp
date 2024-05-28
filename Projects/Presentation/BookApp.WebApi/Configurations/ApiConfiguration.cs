using BookApp.WebApi.Classes.Extensions;
using BookApp.WebApi.Classes.Filters;
using BooksApp.Application;
using BooksApp.Commons;
using BooksApp.Persistence;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BookApp.WebApi.Configurations
{
    public static class ApiConfiguration
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddControllers(options => options.Filters.Add<LogActionFilterAttribute>())
                    .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
                        options.JsonSerializerOptions.WriteIndented = true;
                        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.ConfigureModelBindingExceptionHandling();
            services.AddPersistence(builder.Configuration, DbConfigurations.DbConnectionStringName);
            services.AddApplication();

            return services;
        }

        public static WebApplication AddWebApplication(this WebApplication app)
        {
            app.MigrateDataBase();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.UseErrorHandler();

            app.Run();

            return app;
        }

        public static WebApplicationBuilder AddWebApplicationBuilder(this WebApplicationBuilder builder) 
        {
            builder.AddCommons();

            return builder;
        }
    }
}
