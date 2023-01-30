using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class CartItem : BaseTable
    {
        public int Id { get; set; }

        public Exam Exam { get; set; }
        public int ExamId { get; set; }

        public Cart Cart { get; set; }
        public int CartId { get; set; }

        public int Quantity { get; set; }
    }
}
