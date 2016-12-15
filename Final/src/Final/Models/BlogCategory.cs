using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    [Table("BlogCategory")]
    public class BlogCategory
    {
        [Key]
        [Display(Name = "Mã chủ đề")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        
        [Display(Name = "Tên chủ đề")]
        [Required(ErrorMessage = "Hãy nhập tên chủ đề")]
        [StringLength(256)]
        public string CategoryName { get; set; }

        [Display(Name = "Thứ tự xuất hiện")]
        [Required(ErrorMessage = "Hãy nhập thứ tự")]

        public int OrderNo { get; set; }

        [Display(Name = "Trạng thái")]
        [StringLength(32)]
        public string Status { get; set; }

        [Display(Name = "Mã người dùng")]
        public int? UserId { get; set; } 

        public ApplicationUser BlogAdministrator { get; set; }
       // public ICollection<BlogPost> BlogPosts { get; set; }
    }
}
