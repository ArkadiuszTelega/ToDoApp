using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Web.Http;
using Microsoft.Extensions.Logging;
using RestAPIforToDos.Models;

namespace RestAPIforToDos
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Dependency injection
            services.AddControllers();  
            services.AddDbContext<AppDbContext>();  // Database context (DbContext)
            services.AddScoped<ToDoManager>();
        }

        public void Configure(IApplicationBuilder app, ILogger<Startup> logger)
        {
            // HTTP request pipeline
            app.UseRouting();

            // endpoint routing for the API
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();  // Map all controller routes
            });

            logger.LogInformation("API is available at http://localhost:2323");
        }
    }
}
