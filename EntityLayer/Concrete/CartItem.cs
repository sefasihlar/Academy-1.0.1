namespace EntityLayer.Concrete
{
    public class CartItem
    {
        public int Id { get; set; }



        public Cart Cart { get; set; }
        public int CartId { get; set; }

        public int Quantity { get; set; }
    }
}
