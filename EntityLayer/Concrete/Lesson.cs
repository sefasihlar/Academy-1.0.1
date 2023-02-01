namespace EntityLayer.Concrete
{
    public class Lesson
    {
        public int Id { get; set; }
        public String? Name { get; set; }

        public int ClassId { get; set; }
        public virtual Class Class { get; set; }

        public int UserId { get; set; }
        public virtual AppUser? User { get; set; }

    }
}
