﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Final.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Final.Infrastructure
{
    [HtmlTargetElement("td", Attributes = "identity-role")]
    public class RoleUsersTagHelper : TagHelper
    {
        private UserManager<BlogMember> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        public RoleUsersTagHelper(UserManager<BlogMember> usermgr,
        RoleManager<IdentityRole> rolemgr)
        {
            _userManager = usermgr;
            _roleManager = rolemgr;
        }
        [HtmlAttributeName("identity-role")]
        public string Role { get; set; }
        public override async Task ProcessAsync(TagHelperContext context,
        TagHelperOutput output)
        {
            List<string> names = new List<string>();
            IdentityRole role = await _roleManager.FindByIdAsync(Role);
            if (role != null)
            {
                foreach (var user in _userManager.Users)
                {
                if (user != null
                && await _userManager.IsInRoleAsync(user, role.Name))
                    {
                        names.Add(user.UserName);
                    }
                }
            }
            output.Content.SetContent(names.Count == 0 ?
            "No Users" : string.Join(", ", names));
        }
    }
}