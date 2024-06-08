using BBS_DevWiki.Models;

namespace BBS_DevWiki.DTOs
{
    public static class Extension
    {
        //Convert ArticleType object to ArticleTypeDTO object maintaining all needed field values.
        public static ArticleTypeDTO ToDTO(this ArticleType articleType)
        {
            return new ArticleTypeDTO
            {
                ID = articleType.ID,
                Name = articleType.Name,
                Description = articleType.Description
            };
        }
    }
}