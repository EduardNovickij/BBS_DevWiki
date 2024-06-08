namespace BBS_DevWiki.Migrations
{
    using BBS_DevWiki.Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<BBS_DevWiki.Models.DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BBS_DevWiki.Models.DBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            //Seeding database with article types as initial data.
            context.ArticleTypes.AddOrUpdate(a => a.ID,
                new ArticleType { ID = 1, Name = "Support issue", Description = "Support issue resolving description for maintenance department." },
                new ArticleType { ID = 2, Name = "Technical issue", Description = "Technical issue resolving description for development department." },
                new ArticleType { ID = 3, Name = "Template", Description = "Company article templates." }
            );

            context.SaveChanges();
        }
    }
}
