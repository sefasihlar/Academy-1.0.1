using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections;

namespace WebUI.Models
{
    public class AppRoleListModel
    {
        public List<AppRole> Roles { get; set; }


        public List<UserRole> UserRoles { get; set; }

  
    }
}
