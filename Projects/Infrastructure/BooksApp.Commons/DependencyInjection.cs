using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace BooksApp.Commons
{
    public static class DependencyInjection
    {
        public static WebApplicationBuilder AddCommons(this WebApplicationBuilder builder)
        {
            builder.Logging.ClearProviders();
            builder.Host.UseNLog();

            return builder;
        }
    }
}
