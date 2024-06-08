using BBS_DevWiki.Services;
using BBS_DevWiki.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace BBS_DevWiki.Controllers
{
    public class ArticleTypeController : ApiController
    {
        private readonly IArticleTypeService articleTypeService;

        public ArticleTypeController(IArticleTypeService articleTypeService)
        {
            this.articleTypeService = articleTypeService;
        }

        [HttpGet]
        public async Task<IEnumerable<ArticleTypeDTO>> GetArticleTypes()
        {
            var articleTypes = await articleTypeService.GetArticleTypesAsync();
            var articleTypesDTO = from articleType in articleTypes select articleType.ToDTO();

            return articleTypesDTO;
        }
    }
}
