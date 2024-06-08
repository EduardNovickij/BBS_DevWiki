using System;
using System.ComponentModel.DataAnnotations;

namespace BBS_DevWiki.DTOs
{
    public class ArticleDTO
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime ArticleDate { get; set; }
        public int ArticleTypeID { get; set; }
    }
}