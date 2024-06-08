using BBS_DevWiki.Models;
using BBS_DevWiki.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BBS_DevWiki.Services
{
    public interface IArticleTypeService
    {
        //Get all article types from database and apply business logic if needed.
        Task<IEnumerable<ArticleTypeDTO>> GetArticleTypesAsync();

        //Get article type from database using provided id and apply business logic if needed.
        Task<ArticleType> GetArticleTypeAsync(int id);
    }
}
