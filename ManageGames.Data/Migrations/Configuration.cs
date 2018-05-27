using System.Data.Entity.Migrations;
using ManageGames.Data.Contexts;

namespace ManageGames.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ManageGamesDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ManageGamesDataContext context)
        {

        }
    }
}
