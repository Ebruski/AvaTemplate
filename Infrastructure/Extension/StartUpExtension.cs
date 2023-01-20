using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extension
{
    public static class StartupExtension
    {

        public static void AddDbConnection(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("AvaTemplateDb");
#if !DEBUG
            connectionString = connectionString.Replace("{SQLServerName}", configuration["SQLSERVER_NAME"]);
            connectionString = connectionString.Replace("{SQLServerUser}", configuration["SQLSERVER_USER"]);
            connectionString = connectionString.Replace("{SQLServerPassword}", configuration["SQLSERVER_PASSWORD"]);
#else
            connectionString = configuration.GetConnectionString("AvaTemplateDbLocal");
#endif
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString, x => x.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));

            });
        }
    }
}
