using BBS_DevWiki.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BBS_DevWiki.Repositories
{
    public class ArticleTypeRepository : IArticleTypeRepository
    {
        private readonly DBContext context;

        public ArticleTypeRepository(DBContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<ArticleType>> GetArticleTypesAsync()
        {
            return await context.ArticleTypes.ToListAsync();
        }
        public async Task<ArticleType> GetArticleTypeAsync(int id)
        {
            return await context.ArticleTypes.FindAsync(id);
        }
    }
}