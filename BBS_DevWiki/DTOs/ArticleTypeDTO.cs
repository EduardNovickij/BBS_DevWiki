using System.ComponentModel.DataAnnotations;

namespace BBS_DevWiki.DTOs
{
    public class ArticleTypeDTO
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}