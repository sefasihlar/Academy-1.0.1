using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int UserId { get; set; }
        public virtual AppUser User { get; set; }

        public List<Question> Questions { get; set; }

    }
}
