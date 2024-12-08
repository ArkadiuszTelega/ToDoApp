using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using RestAPIforToDos.Models;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestAPIforToDos
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            // Start the Kestrel server in a separate task
            Task.Run(() => StartApiServer(args));

            // Start the Windows Forms application
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(new ToDoManager(new AppDbContext())));
        }

        private static void StartApiServer(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("http://localhost:2323");
                });
    }
}
