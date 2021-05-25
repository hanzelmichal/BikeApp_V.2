using System;
using BikeApp.Areas.Identity.Data;
using BikeApp.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(BikeApp.Areas.Identity.IdentityHostingStartup))]
namespace BikeApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<BikeAuthContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("BikeAuthContextConnection")));

                services.AddDefaultIdentity<AplicationUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                })
                    .AddEntityFrameworkStores<BikeAuthContext>();
            });
        }
    }
}