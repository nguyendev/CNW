using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Areas.Wp_admin.ViewModels
{
    public class User
    {
        public string ID { get; set; }
        public int AccessFailedCount { get; set; }
        public string ConcurrencyStamp { get; set; }
	 public string Email { get; set; }
        public string EmailConfirmed { get; set; }
	    public string LockoutEnable { get; set; }

    public string LockoutEnd { get; set; }
        public string NormalizeEmail { get; set; }
        public string NormalizedUserName { get; set; }
	public string PasswordHash { get; set; }
	public string PhoneNumber { get; set; }
            public string PhoneNumberConfirmed { get; set; }
public string SecurityStamp { get; set; }
            public string UserName { get; set; }
    }
}
