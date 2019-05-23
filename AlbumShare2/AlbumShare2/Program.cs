using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AlbumShare2.DAL;
using AlbumShare2.Models;

namespace AlbumShare2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host=CreateWebHostBuilder(args).Build();

            //MSDocs method for data initialization
            //https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/working-with-sql?view=aspnetcore-2.2&tabs=visual-studio
            var services = host.Services.CreateScope().ServiceProvider;
            InitData.Initialize(services);
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
