﻿namespace EntityLayer.Concrete
{
    public class CartItem
    {
        public int Id { get; set; }

        public Cart Cart { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        public Boolean Condition { get; set; }
    }
}
