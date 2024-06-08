using BBS_DevWiki.Models;
using BBS_DevWiki.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BBS_DevWiki.Services
{
    public class ArticleTypeService : IArticleTypeService
    {
        private readonly IArticleTypeRepository repository;

        public ArticleTypeService(IArticleTypeRepository repository)
        {
            this.repository = repository;
        }
        public async Task<ArticleType> GetArticleTypeAsync(int id)
        {
            return await repository.GetArticleTypeAsync(id);
        }

        public async Task<IEnumerable<ArticleType>> GetArticleTypesAsync()
        {
            return await repository.GetArticleTypesAsync();
        }
    }
}