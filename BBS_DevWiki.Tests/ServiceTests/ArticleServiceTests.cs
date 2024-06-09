using BBS_DevWiki.DTOs;
using BBS_DevWiki.Models;
using BBS_DevWiki.Repositories;
using BBS_DevWiki.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Moq;

namespace BBS_DevWiki.Tests
{
    public class ArticleServiceTests
    {
        [Fact]
        public async Task CreateArticleAsync_ShouldCreateArticle()
        {
            // Arrange
            var mockRepository = new Mock<IArticleRepository>();
            var articleDTO = new CreateArticleDTO
            {
                Title = "Test Title",
                Description = "Test Description",
                ArticleDate = DateTime.Now.ToString("yyyy-MM-dd"),
                ArticleTypeID = 1
            };
            var article = articleDTO.FromDTO();
            article.ID = 1; // Simulate the DB assigning an ID

            mockRepository.Setup(repo => repo.CreateArticleAsync(It.IsAny<Article>()))
                .ReturnsAsync(article);

            var service = new ArticleService(mockRepository.Object);

            // Act
            var result = await service.CreateArticleAsync(articleDTO);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(article.Title, result.Title);
            Assert.Equal(article.Description, result.Description);
            Assert.Equal(article.ArticleDate, result.ArticleDate);
            Assert.Equal(article.ArticleTypeID, result.ArticleTypeID);
            Assert.Equal(article.ID, result.ID);
        }

        [Fact]
        public async Task GetArticleAsync_ShouldReturnArticle()
        {
            // Arrange
            var mockRepository = new Mock<IArticleRepository>();
            var article = new Article
            {
                ID = 1,
                Title = "Test Title",
                Description = "Test Description",
                ArticleDate = DateTime.Now,
                ArticleTypeID = 1
            };

            mockRepository.Setup(repo => repo.GetArticleAsync(1))
                .ReturnsAsync(article);

            var service = new ArticleService(mockRepository.Object);

            // Act
            var result = await service.GetArticleAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(article.ID, result.ID);
            Assert.Equal(article.Title, result.Title);
            Assert.Equal(article.Description, result.Description);
            Assert.Equal(article.ArticleDate, result.ArticleDate);
            Assert.Equal(article.ArticleTypeID, result.ArticleTypeID);
        }

        [Fact]
        public async Task GetArticlesAsync_ShouldReturnAllArticles()
        {
            // Arrange
            var mockRepository = new Mock<IArticleRepository>();
            var articles = new List<Article>
        {
            new Article { ID = 1, Title = "Test Title 1", Description = "Test Description 1", ArticleDate = DateTime.Now, ArticleTypeID = 1 },
            new Article { ID = 2, Title = "Test Title 2", Description = "Test Description 2", ArticleDate = DateTime.Now, ArticleTypeID = 2 }
        };

            mockRepository.Setup(repo => repo.GetArticlesAsync())
                .ReturnsAsync(articles);

            var service = new ArticleService(mockRepository.Object);

            // Act
            var result = await service.GetArticlesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Contains(result, a => a.ID == 1);
            Assert.Contains(result, a => a.ID == 2);
        }

        [Fact]
        public async Task DeleteArticleAsync_ShouldCallRepositoryDelete()
        {
            // Arrange
            var mockRepository = new Mock<IArticleRepository>();

            mockRepository.Setup(repo => repo.DeleteArticleAsync(1))
                .Returns(Task.CompletedTask);

            var service = new ArticleService(mockRepository.Object);

            // Act
            await service.DeleteArticleAsync(1);

            // Assert
            mockRepository.Verify(repo => repo.DeleteArticleAsync(1), Times.Once);
        }
    }
}
