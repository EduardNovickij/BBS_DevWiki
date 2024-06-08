using BBS_DevWiki.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BBS_DevWiki.Repositories
{
    public interface IArticleTypeRepository
    {
        //Get all article types that are stored in the database.
        Task<IEnumerable<ArticleType>> GetArticleTypesAsync();

        //Get article type using provided id.
        Task<ArticleType> GetArticleTypeAsync(int id);
    }
}
