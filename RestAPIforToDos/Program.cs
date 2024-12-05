using System;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using Owin;
using System.Windows.Forms;
using RestAPIforToDos.Models;
using Microsoft.EntityFrameworkCore;

namespace RestAPIforToDos
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:2323/";
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                using (var context = new AppDbContext())
                {
                    EnsureDatabaseCreated(context);
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm(new ToDoManager(new AppDbContext())));
            }
        }

        static void EnsureDatabaseCreated(AppDbContext context)
        {
            try
            {
                if (context.Database.EnsureCreated())
                {
                    Console.WriteLine("Database created and migrated.");
                }
                else
                {
                    Console.WriteLine("Database already exists. Applying any pending migrations...");
                    context.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while ensuring database creation: {ex.Message}");
            }
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder.UseWebApi(config);
        }
    }
}
