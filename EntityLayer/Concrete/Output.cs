using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Output : BaseTable
    {
        public string Name { get; set; }

        public int UserId { get; set; }
        public AppUser User { get; set; }
    }
}
