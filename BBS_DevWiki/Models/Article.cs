using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BBS_DevWiki.Models
{
    public class Article
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }

        public DateTime ArticleDate { get; set; }

        [ForeignKey("ArticleType")]
        public int ArticleTypeID { get; set; }

        public virtual ArticleType ArticleType { get; set; }
    }
}