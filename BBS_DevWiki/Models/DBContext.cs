using System.Data.Common;
using System.Data.Entity;

namespace BBS_DevWiki.Models
{
    public class DBContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleType> ArticleTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Describing realtionship between Articles and ArticleTypes tables.
            modelBuilder.Entity<Article>()
                .HasRequired(e => e.ArticleType)
                .WithMany(e => e.Articles)
                .HasForeignKey(e => e.ArticleTypeID);
        }

        //Constructors to allow passing of the connection for testing.
        public DBContext(DbConnection connection) : base(connection, true) { }

        public DBContext() : base() { }
    }
}