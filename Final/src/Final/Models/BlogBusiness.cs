using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final.Models
{
    [Table("BlogBusiness")]
    public class BlogBusiness
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BusinessId { get; set; }

        [MaxLength(64)]
        [Display(Name = "Mã nghiệp vụ")]
        public string BusinessCode { get; set; }

        [Required(ErrorMessage = "Hãy nhập tên nghiệp vụ")]
        [Display(Name = "Tên nghiệp vụ")]
        [MaxLength(256)]
        public string BusinessName { get; set; }
        public ICollection<BlogPermission> BlogPermissions { get; set; }
    }
}
