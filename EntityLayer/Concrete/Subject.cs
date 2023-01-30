using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Subject : BaseTable
    {
        public string Name { get; set; }

        public int UserId { get; set; }
        public AppUser User { get; set; }
    }
}
