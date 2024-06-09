using BBS_DevWiki.Models;
using BBS_DevWiki.Repositories;
using BBS_DevWiki.Services;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BBS_DevWiki.Tests
{
    public class ArticleTypeServiceTests
    {
        [Fact]
        public async Task GetArticleTypeAsync_ShouldReturnArticleType()
        {
            // Arrange
            var mockRepository = new Mock<IArticleTypeRepository>();
            var articleType = new ArticleType
            {
                ID = 1,
                Name = "Type1",
                Description = "Description1"
            };

            mockRepository.Setup(repo => repo.GetArticleTypeAsync(1))
                .ReturnsAsync(articleType);

            var service = new ArticleTypeService(mockRepository.Object);

            // Act
            var result = await service.GetArticleTypeAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(articleType.ID, result.ID);
            Assert.Equal(articleType.Name, result.Name);
            Assert.Equal(articleType.Description, result.Description);
        }

        [Fact]
        public async Task GetArticleTypeAsync_ShouldReturnNullIfNotFound()
        {
            // Arrange
            var mockRepository = new Mock<IArticleTypeRepository>();

            mockRepository.Setup(repo => repo.GetArticleTypeAsync(99)) // ID that doesn't exist
                .ReturnsAsync((ArticleType)null);

            var service = new ArticleTypeService(mockRepository.Object);

            // Act
            var result = await service.GetArticleTypeAsync(99);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetArticleTypesAsync_ShouldReturnAllArticleTypes()
        {
            // Arrange
            var mockRepository = new Mock<IArticleTypeRepository>();
            var articleTypes = new List<ArticleType>
        {
            new ArticleType { ID = 1, Name = "Type1", Description = "Description1" },
            new ArticleType { ID = 2, Name = "Type2", Description = "Description2" }
        };

            mockRepository.Setup(repo => repo.GetArticleTypesAsync())
                .ReturnsAsync(articleTypes);

            var service = new ArticleTypeService(mockRepository.Object);

            // Act
            var result = await service.GetArticleTypesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Contains(result, at => at.ID == 1);
            Assert.Contains(result, at => at.ID == 2);
        }
    }
}
