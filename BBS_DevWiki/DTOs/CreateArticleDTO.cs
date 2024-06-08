using System.ComponentModel.DataAnnotations;

namespace BBS_DevWiki.DTOs
{
    public class CreateArticleDTO
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int ArticleTypeID { get; set; }

        [Required]
        public string ArticleDate { get; set; }
    }
}