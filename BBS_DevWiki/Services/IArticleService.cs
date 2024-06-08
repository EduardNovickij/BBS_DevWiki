using BBS_DevWiki.Models;
using BBS_DevWiki.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BBS_DevWiki.Services
{
    public interface IArticleService
    {
        //Apply business logic to article data if needed and add new article to the database.
        Task<ArticleDTO> CreateArticleAsync(CreateArticleDTO articleDTO);

        //Get article from the database using provided id and apply business logic if needed.
        Task<ArticleDTO> GetArticleAsync(int id);

        //Get all articles from the database and apply business logic if needed.
        Task<IEnumerable<ArticleDTO>> GetArticlesAsync();

        //Delete article from the database using provided id.
        Task DeleteArticleAsync(int id);
    }
}
