using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using TheDynamicKarateCupV2.Models;

namespace TheDynamicKarateCupV2.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            //adaptions for the many to many problem
            builder.Entity<CompetitorCategory>()
                .HasKey(t => new { t.CompetitorID, t.CategoryID });

            builder.Entity<CompetitorCategory>()
                .HasOne(cc => cc.Competitor)
                .WithMany(c => c.CompetitorCategories)
                .HasForeignKey(cc => cc.CompetitorID);

            builder.Entity<CompetitorCategory>()
                .HasOne(cc => cc.Category)
                .WithMany(c => c.CompetitorCategories)
                .HasForeignKey(cc => cc.CategoryID);
        }

        public DbSet<Club> Club { get; set; }
        public DbSet<Competitor> Competitor { get; set; }
        public DbSet<Coach> Coach { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
