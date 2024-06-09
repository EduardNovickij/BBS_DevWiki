using BBS_DevWiki.Models;
using BBS_DevWiki.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BBS_DevWiki.Tests
{
    public class ArticleTypesRepositoryTests
    {
        private DBContext CreateInMemoryDbContext()
        {
            var connection = Effort.DbConnectionFactory.CreateTransient();
            var context = new DBContext(connection);

            // Seed the ArticleTypes table
            context.ArticleTypes.AddRange(new List<ArticleType>
        {
            new ArticleType { ID = 1, Name = "Type1", Description = "Description1" },
            new ArticleType { ID = 2, Name = "Type2", Description = "Description2" }
        });

            context.SaveChanges();
            return context;
        }

        [Fact]
        public async Task GetArticleTypesAsync_ShouldReturnAllArticleTypes()
        {
            using (var context = CreateInMemoryDbContext())
            {
                var repository = new ArticleTypeRepository(context);

                var articleTypes = await repository.GetArticleTypesAsync();

                Assert.Equal(2, articleTypes.Count());
                Assert.Contains(articleTypes, at => at.Name == "Type1" && at.Description == "Description1");
                Assert.Contains(articleTypes, at => at.Name == "Type2" && at.Description == "Description2");
            }
        }

        [Fact]
        public async Task GetArticleTypeAsync_ShouldReturnArticleType()
        {
            using (var context = CreateInMemoryDbContext())
            {
                var repository = new ArticleTypeRepository(context);

                var articleType = await repository.GetArticleTypeAsync(1);

                Assert.NotNull(articleType);
                Assert.Equal(1, articleType.ID);
                Assert.Equal("Type1", articleType.Name);
                Assert.Equal("Description1", articleType.Description);
            }
        }

        [Fact]
        public async Task GetArticleTypeAsync_ShouldReturnNullIfNotFound()
        {
            using (var context = CreateInMemoryDbContext())
            {
                var repository = new ArticleTypeRepository(context);

                var articleType = await repository.GetArticleTypeAsync(99); // ID that doesn't exist

                Assert.Null(articleType);
            }
        }
    }
}

