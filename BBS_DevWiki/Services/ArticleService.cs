using BBS_DevWiki.DTOs;
using BBS_DevWiki.Models;
using BBS_DevWiki.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBS_DevWiki.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository repository;

        public ArticleService(IArticleRepository repository)
        {
            this.repository = repository;
        }
        public async Task<ArticleDTO> CreateArticleAsync(CreateArticleDTO articleDTO)
        {
            var article = await repository.CreateArticleAsync(articleDTO.FromDTO());
            return article.ToDTO();
        }

        public async Task<ArticleDTO> GetArticleAsync(int id)
        {
            var article = await repository.GetArticleAsync(id);
            return article.ToDTO();
        }

        public async Task<IEnumerable<ArticleDTO>> GetArticlesAsync()
        {
            var articles = await repository.GetArticlesAsync();
            var articleDTOs = from article in articles select article.ToDTO();
            return articleDTOs;
        }

        public async Task DeleteArticleAsync(int id)
        {
            await repository.DeleteArticleAsync(id);
        }
    }
}