using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message : BaseTable
    {
        public string Title { get; set; }
        public string Text { get; set; }

        public int UserId { get; set; }
        public AppUser User { get; set; }

    }
}
