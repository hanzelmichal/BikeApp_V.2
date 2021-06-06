using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeApp.Areas.Identity.Data;
using BikeApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BikeApp.Data
{
    public class BikeAuthContext : IdentityDbContext<AplicationUser>
    {
        public BikeAuthContext(DbContextOptions<BikeAuthContext> options)
            : base(options)
        {
        }

        DbSet<UserRoute> UserRoute { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserRoute>().ToTable("UserRoute").HasKey(x => new { x.UserId });
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
