using BBS_DevWiki.Controllers;
using BBS_DevWiki.DTOs;
using BBS_DevWiki.Services;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BBS_DevWiki.Tests
{
    public class ArticleTypeControllerTests
    {
        private Mock<IArticleTypeService> mockArticleTypeService;
        private ArticleTypeController controller;

        public ArticleTypeControllerTests()
        {
            mockArticleTypeService = new Mock<IArticleTypeService>();
            controller = new ArticleTypeController(mockArticleTypeService.Object);
        }

        [Fact]
        public async Task GetArticleTypes_ShouldReturnAllArticleTypes()
        {
            // Arrange
            var articleTypes = new List<ArticleTypeDTO>
        {
            new ArticleTypeDTO { ID = 1, Name = "Type1", Description = "Description1" },
            new ArticleTypeDTO { ID = 2, Name = "Type2", Description = "Description2" }
        };

            mockArticleTypeService.Setup(s => s.GetArticleTypesAsync()).ReturnsAsync(articleTypes);

            // Act
            var result = await controller.GetArticleTypes();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Contains(result, at => at.ID == 1);
            Assert.Contains(result, at => at.ID == 2);
        }
    }
}
