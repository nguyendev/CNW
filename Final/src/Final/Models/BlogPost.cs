﻿using System;
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
        [Display(Name = "ID")]
        public string ID { get; set; }

        [Display(Name ="URL")]
        public string URL { get; set; }

        [Display(Name = "Nội dung")]
        [Required]
        public string Content { get; set; }

        [Display(Name = "Ghi chú")]
        public string Notes { get; set; }

        [Display(Name = "Ngày tạo")]
        public Nullable<System.DateTime> Create_DT { get; set; }

        [Display(Name = "Trạng thái")]
        public string Auth_status { get; set; }

        [Display(Name = "Người duyệt")]
        public string Checker_ID { get; set; }
        [Display(Name = "Ngày xuất bản")]
        public Nullable<System.DateTime> Publish_DT { get; set; }

        public int Record_Status { get; set; }
        public string AuthorId { get; set; }

        public virtual BlogMember Author { get; set; }

        [Display(Name = "Danh mục")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual BlogCategory Category { get; set; }

    }
}
