using System.Data.Entity.Migrations;
using ManageGames.Web.Models;

namespace ManageGames.Web.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {

        }
    }
}
