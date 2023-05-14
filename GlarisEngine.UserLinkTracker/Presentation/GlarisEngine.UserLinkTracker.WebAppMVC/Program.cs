using Autofac.Extensions.DependencyInjection;
using Autofac;
using GlarisEngine.UserLinkTracker.WebAppMVC.IOC;
using ManagePolicy.WebApp.Extensions.AutoMapper;
using NLog.Web;
using GlarisEngine.UserLinkTracker.WebAppMVC.Extensions.CustomFilters;
using GlarisEngine.UserLinkTracker.Infrastructure.Logging;
using NLog;

namespace GlarisEngine.UserLinkTracker.WebAppMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add(typeof(LoggingActionFilter));
            });

            var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
                    .ConfigureContainer<ContainerBuilder>(builder =>
                    {
                        builder.Register(c => new LogInterceptor(logger)).SingleInstance();
                        builder.RegisterModule(new ServiceIOCModule());
                        builder.RegisterModule(new RepositoryIOCModule("Data Source=VIJI\\SQLEXPRESS;Initial Catalog=GlarisEngine_UserLinkTracker;Integrated Security=True"));
                    });
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile)); // Service (Auto Mapper)
            // NLog: Setup NLog for Dependency injection
            builder.Logging.ClearProviders();
            builder.Host.UseNLog();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}