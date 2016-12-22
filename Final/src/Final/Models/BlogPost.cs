using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    [Table("BlogPost")]
    public class BlogPost
    {
        [Display(Name = "URL")]
        public string URL { get; set; }

        [Display(Name = "Nhận xét")]
        [Required]
        public string Comment { get; set; }

        [Display(Name = "")]
        [Required]
        public string Content { get; set; }

        [Display(Name = "Date Created")]
        public DateTime Created { get; set; }

        [Display(Name = "Date Published")]
        public DateTime? Published { get; set; }

        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual ApplicationUser Author { get; set; }
    }
}
