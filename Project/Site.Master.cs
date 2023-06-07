using Project.Database;
using Project.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProjectDbContext projectDbContext = new ProjectDbContext();
            var configuration = new DbMigrationsConfiguration<ProjectDbContext>();
            //{
            //    // Set the appropriate connection string name
            //    TargetDatabase = new DbConnectionInfo("YourConnectionStringName")
            //};

            var migrator = new DbMigrator(new Configuration());
            //migrator.Configuration.AutomaticMigrationDataLossAllowed = true; // Optional: Prevent data loss during automatic migrations

            // Get the pending migrations
            var migrations = migrator.GetPendingMigrations();

            // Apply the pending migrations
           
            if (migrations.Any())
            {
                migrator.Update();
                Console.WriteLine("Database migrations applied successfully.");
            }
            else
            {
                Console.WriteLine("No pending migrations found.");
            }
        }
    }
}