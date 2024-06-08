using BBS_DevWiki.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BBS_DevWiki.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly DBContext context;

        public ArticleRepository(DBContext context)
        {
            this.context = context;
        }
        public async Task<Article> CreateArticleAsync(Article article)
        {
            context.Articles.Add(article);
            await context.SaveChangesAsync();

            return article;
        }

        public async Task<IEnumerable<Article>> GetArticlesAsync()
        {
            return await context.Articles.ToListAsync();
        }
        public async Task<Article> GetArticleAsync(int id)
        {
            return await context.Articles.FindAsync(id);
        }
        public async Task DeleteArticleAsync(int id)
        {
            var article = await context.Articles.FindAsync(id);

            context.Articles.Remove(article);
            await context.SaveChangesAsync();
        }
    }
}