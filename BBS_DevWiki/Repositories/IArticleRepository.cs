using BBS_DevWiki.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BBS_DevWiki.Repositories
{
    public interface IArticleRepository
    {
        /*Inserts new article into the database, and if new article was successfully created returns it with assigned id, 
          otherwise returns null.*/
        Task<Article> CreateArticleAsync(Article article);

        //Get all articles that are stored in the database.
        Task<IEnumerable<Article>> GetArticlesAsync();

        //Get article from the database using provided id.
        Task<Article> GetArticleAsync(int id);

        //Delete article from the database using provided id.
        Task DeleteArticleAsync(int id);
    }
}
