using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final.Models
{
    [Table("BlogPermission")]
    public class BlogPermission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PermissionId { get; set; }

        [Required(ErrorMessage = "Hãy nhập tên quyền hạn")]
        [Display(Name = "Tên quyền")]
        [Column(TypeName = "varchar(256)")]
        [MaxLength(256)]
        public string PermissionName { get; set; }

        [Required(ErrorMessage = "Hãy nhập mô tả quyền hạn")]
        [Display(Name = "Mô tả")]
        [MaxLength(256)]
        public string Description { get; set; }

        [Required]
        [MaxLength(64)]
        [Display(Name = "Mã nghiệp vụ")]
        [Column(TypeName = "varchar(64)")]
        public string BussinessCode { get; set; }
        public BlogBusiness BlogBusinesses { get; set; }

       // public ICollection<AppRole> GrantPermissions { get; set; }
    }

}
