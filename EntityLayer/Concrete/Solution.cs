namespace EntityLayer.Concrete
{
    public class Solution
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        public Boolean Condition { get; set; }

    }
}
