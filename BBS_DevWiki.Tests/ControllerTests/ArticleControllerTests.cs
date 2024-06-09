using BBS_DevWiki.Controllers;
using BBS_DevWiki.DTOs;
using BBS_DevWiki.Models;
using BBS_DevWiki.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using System.Threading.Tasks;
using Xunit;

namespace BBS_DevWiki.Tests
{
    public class ArticleControllerTests
    {
        private Mock<IArticleService> mockArticleService;
        private Mock<IArticleTypeService> mockArticleTypeService;
        private ArticleController controller;

        public ArticleControllerTests()
        {
            mockArticleService = new Mock<IArticleService>();
            mockArticleTypeService = new Mock<IArticleTypeService>();
            controller = new ArticleController(mockArticleService.Object, mockArticleTypeService.Object);
        }

        [Fact]
        public async Task PostArticle_ShouldReturnCreatedArticle()
        {
            // Arrange
            var createArticleDTO = new CreateArticleDTO
            {
                Title = "Test Title",
                Description = "Test Description",
                ArticleDate = DateTime.Now.ToString("yyyy-MM-dd"),
                ArticleTypeID = 1
            };
            var articleDTO = new ArticleDTO
            {
                ID = 1,
                Title = "Test Title",
                Description = "Test Description",
                ArticleDate = DateTime.Now,
                ArticleTypeID = 1
            };

            mockArticleTypeService.Setup(s => s.GetArticleTypeAsync(1)).ReturnsAsync(new ArticleType { ID = 1, Name = "Type1", Description = "Description1" });
            mockArticleService.Setup(s => s.CreateArticleAsync(It.IsAny<CreateArticleDTO>())).ReturnsAsync(articleDTO);

            // Act
            var result = await controller.PostArticle(createArticleDTO) as CreatedAtRouteNegotiatedContentResult<ArticleDTO>;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("DefaultApi", result.RouteName);
            Assert.Equal(1, result.RouteValues["id"]);
            Assert.Equal(articleDTO, result.Content);
        }

        [Fact]
        public async Task PostArticle_ShouldReturnBadRequest_IfModelIsInvalid()
        {
            // Arrange
            controller.ModelState.AddModelError("Title", "Required");

            // Act
            var result = await controller.PostArticle(new CreateArticleDTO()) as InvalidModelStateResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task PostArticle_ShouldReturnBadRequest_IfArticleTypeDoesNotExist()
        {
            // Arrange
            var createArticleDTO = new CreateArticleDTO
            {
                Title = "Test Title",
                Description = "Test Description",
                ArticleDate = DateTime.Now.ToString("yyyy-MM-dd"),
                ArticleTypeID = 99 // Non-existing ArticleTypeID
            };

            mockArticleTypeService.Setup(s => s.GetArticleTypeAsync(99)).ReturnsAsync((ArticleType)null);

            // Act
            var result = await controller.PostArticle(createArticleDTO) as BadRequestErrorMessageResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Selected article type does not exist within database.", result.Message);
        }

        [Fact]
        public async Task PostArticle_ShouldReturnBadRequest_IfArticleDateIsInvalid()
        {
            // Arrange
            var createArticleDTO = new CreateArticleDTO
            {
                Title = "Test Title",
                Description = "Test Description",
                ArticleDate = "Invalid Date",
                ArticleTypeID = 1
            };

            mockArticleTypeService.Setup(s => s.GetArticleTypeAsync(1)).ReturnsAsync(new ArticleType { ID = 1, Name = "Type1", Description = "Description1" });

            // Act
            var result = await controller.PostArticle(createArticleDTO) as BadRequestErrorMessageResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Selected date does not correspond to Date format.", result.Message);
        }

        [Fact]
        public async Task GetArticle_ShouldReturnArticle_IfExists()
        {
            // Arrange
            var articleDTO = new ArticleDTO
            {
                ID = 1,
                Title = "Test Title",
                Description = "Test Description",
                ArticleDate = DateTime.Now,
                ArticleTypeID = 1
            };

            mockArticleService.Setup(s => s.GetArticleAsync(1)).ReturnsAsync(articleDTO);

            // Act
            var result = await controller.GetArticle(1) as OkNegotiatedContentResult<ArticleDTO>;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(articleDTO, result.Content);
        }

        [Fact]
        public async Task GetArticle_ShouldReturnNotFound_IfDoesNotExist()
        {
            // Arrange
            mockArticleService.Setup(s => s.GetArticleAsync(1)).ReturnsAsync((ArticleDTO)null);

            // Act
            var result = await controller.GetArticle(1) as NotFoundResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetArticles_ShouldReturnAllArticles()
        {
            // Arrange
            var articles = new List<ArticleDTO>
        {
            new ArticleDTO { ID = 1, Title = "Test Title 1", Description = "Test Description 1", ArticleDate = DateTime.Now, ArticleTypeID = 1 },
            new ArticleDTO { ID = 2, Title = "Test Title 2", Description = "Test Description 2", ArticleDate = DateTime.Now, ArticleTypeID = 2 }
        };

            mockArticleService.Setup(s => s.GetArticlesAsync()).ReturnsAsync(articles);

            // Act
            var result = await controller.GetArticles();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task DeleteArticle_ShouldReturnOk_IfArticleExists()
        {
            // Arrange
            var articleDTO = new ArticleDTO
            {
                ID = 1,
                Title = "Test Title",
                Description = "Test Description",
                ArticleDate = DateTime.Now,
                ArticleTypeID = 1
            };

            mockArticleService.Setup(s => s.GetArticleAsync(1)).ReturnsAsync(articleDTO);
            mockArticleService.Setup(s => s.DeleteArticleAsync(1)).Returns(Task.CompletedTask);

            // Act
            var result = await controller.DeleteArticle(1) as OkResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task DeleteArticle_ShouldReturnNotFound_IfArticleDoesNotExist()
        {
            // Arrange
            mockArticleService.Setup(s => s.GetArticleAsync(1)).ReturnsAsync((ArticleDTO)null);

            // Act
            var result = await controller.DeleteArticle(1) as NotFoundResult;

            // Assert
            Assert.NotNull(result);
        }
    }
}
