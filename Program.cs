using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Globalization;

namespace TestingBlazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("sl");
            ValidatorOptions.Global.CascadeMode = CascadeMode.Stop;

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
