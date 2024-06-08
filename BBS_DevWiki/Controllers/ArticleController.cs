using BBS_DevWiki.Services;
using BBS_DevWiki.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System;

namespace BBS_DevWiki.Controllers
{
    public class ArticleController : ApiController
    {
        private readonly IArticleService articleService;
        private readonly IArticleTypeService articleTypeService;

        public ArticleController(IArticleService articleService, IArticleTypeService articleTypeService)
        {
            this.articleService = articleService;
            this.articleTypeService = articleTypeService;
        }

        [HttpPost]
        [ResponseType(typeof(ArticleDTO))]
        public async Task<IHttpActionResult> PostArticle(CreateArticleDTO articleCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var articleType = await articleTypeService.GetArticleTypeAsync(articleCreateDTO.ArticleTypeID);
            if (articleType is null)
            {
                return BadRequest("Selected article type does not exist within database.");
            }

            try { DateTime.Parse(articleCreateDTO.ArticleDate); }
            catch
            {
                return BadRequest("Selected date does not correspond to Date format.");
            }

            var article = await articleService.CreateArticleAsync(articleCreateDTO);

            return CreatedAtRoute("DefaultApi", new { id = article.ID }, article);
        }

        [HttpGet]
        [ResponseType(typeof(ArticleDTO))]
        public async Task<IHttpActionResult> GetArticle(int id)
        {
            var article = await articleService.GetArticleAsync(id);
            if (article is null)
            {
                return NotFound();
            }

            return Ok(article);
        }

        [HttpGet]
        public async Task<IEnumerable<ArticleDTO>> GetArticles()
        {
            return await articleService.GetArticlesAsync();
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteArticle(int id)
        {
            var article = await articleService.GetArticleAsync(id);
            if (article is null)
            {
                return NotFound();
            }

            await articleService.DeleteArticleAsync(id);
            return Ok();
        }
    }
}