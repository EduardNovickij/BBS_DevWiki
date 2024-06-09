using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using BBS_DevWiki.Models;
using BBS_DevWiki.Repositories;

namespace BBS_DevWiki.Tests
{
    public class ArticleRepositoryTests
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
        public async Task CreateArticleAsync_ShouldAddArticle()
        {
            using (var context = CreateInMemoryDbContext())
            {
                var repository = new ArticleRepository(context);

                var article = new Article { ID = 1, Title = "Title1", Description = "Description1", ArticleDate = DateTime.Now, ArticleTypeID = 1 };

                var result = await repository.CreateArticleAsync(article);

                Assert.Equal(article, result);
                Assert.Equal(1, await context.Articles.CountAsync());
            }
        }

        [Fact]
        public async Task GetArticlesAsync_ShouldReturnAllArticles()
        {
            using (var context = CreateInMemoryDbContext())
            {
                context.Articles.AddRange(new List<Article>
            {
                new Article { ID = 1, Title = "Title1", Description = "Description1", ArticleDate = DateTime.Now, ArticleTypeID = 1 },
                new Article { ID = 2, Title = "Title2", Description = "Description2", ArticleDate = DateTime.Now, ArticleTypeID = 2 }
            });
                await context.SaveChangesAsync();

                var repository = new ArticleRepository(context);
                var articles = await repository.GetArticlesAsync();

                Assert.Equal(2, articles.Count());
            }
        }

        [Fact]
        public async Task GetArticleAsync_ShouldReturnArticle()
        {
            using (var context = CreateInMemoryDbContext())
            {
                var article = new Article { ID = 1, Title = "Title1", Description = "Description1", ArticleDate = DateTime.Now, ArticleTypeID = 1 };
                context.Articles.Add(article);
                await context.SaveChangesAsync();

                var repository = new ArticleRepository(context);
                var result = await repository.GetArticleAsync(1);

                Assert.Equal(article, result);
            }
        }

        [Fact]
        public async Task DeleteArticleAsync_ShouldRemoveArticle()
        {
            using (var context = CreateInMemoryDbContext())
            {
                var article = new Article { ID = 1, Title = "Title1", Description = "Description1", ArticleDate = DateTime.Now, ArticleTypeID = 1 };
                context.Articles.Add(article);
                await context.SaveChangesAsync();

                var repository = new ArticleRepository(context);
                await repository.DeleteArticleAsync(1);

                Assert.Null(await context.Articles.FindAsync(1));
            }
        }
    }
}
