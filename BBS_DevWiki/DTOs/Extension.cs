using BBS_DevWiki.Models;
using System;

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

        //Convert Article object to ArticleDTO object maintaining all needed field values.
        public static ArticleDTO ToDTO(this Article article)
        {
            return new ArticleDTO
            {
                ID = article.ID,
                Title = article.Title,
                Description = article.Description,
                ArticleDate = article.ArticleDate,
                ArticleTypeID = article.ArticleTypeID
            };
        }

        //Convert ArticleDTO object to Article object maintaining all needed field values.
        public static Article FromDTO(this ArticleDTO article)
        {
            return new Article
            {
                ID = article.ID,
                Title = article.Title,
                Description = article.Description,
                ArticleDate = article.ArticleDate,
                ArticleTypeID = article.ArticleTypeID
            };
        }

        //Convert CreateArticleDTO object to Article object maintaining all needed field values.
        public static Article FromDTO(this CreateArticleDTO article)
        {
            return new Article
            {
                Title = article.Title,
                Description = article.Description,
                ArticleDate = DateTime.Parse(article.ArticleDate),
                ArticleTypeID = article.ArticleTypeID
            };
        }
    }
}