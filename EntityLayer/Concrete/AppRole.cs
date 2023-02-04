using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;

namespace EntityLayer.Concrete
{
    public class AppRole : IdentityRole<int>
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now; 

        public Boolean Condition { get; set; }
    }
}
