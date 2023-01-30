using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Lesson : BaseTable
    {
        public String? Name { get; set; }

        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }

        public int ClassId { get; set; }
        public Class? Class { get; set; }

        public int UserId { get; set; }
        public AppUser? User { get; set; }
    }
}
