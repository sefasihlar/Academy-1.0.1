namespace WebUI.Models
{
    public class CartModel
    {
        public int CartId { get; set; }
        public List<CartItemModel> CartItems { get; set; }

 
    }
    public class CartItemModel
    {
        public int CartItemId { get; set; }
        public int ExamId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

    }
}
