using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Areas.Wp_admin.ViewModels
{
    public class DashboardViewModels
    {
        public List<BlogCategory> Cateogory { get; set; }
        public List<BlogPost> Post { get; set; }
        public IList<object> types;
        public int CountUser { get; set; }
        public int CountRole { get; set; }
        public int CountManager { get; set; }

        public List<BlogMember> Member {get;set;}
        public DashboardViewModels()
        {
            List<BlogCategory> Cateogory = new List<BlogCategory>();
            List<BlogPost> Post = new List<BlogPost>();
        }
    } 
}
