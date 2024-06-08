using BBS_DevWiki.Models;
using BBS_DevWiki.Repositories;
using BBS_DevWiki.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

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

        public async Task<IEnumerable<ArticleTypeDTO>> GetArticleTypesAsync()
        {
            var articleTypes = await repository.GetArticleTypesAsync();
            var articleTypesDTO = from articleType in articleTypes select articleType.ToDTO();

            return articleTypesDTO;
        }
    }
}