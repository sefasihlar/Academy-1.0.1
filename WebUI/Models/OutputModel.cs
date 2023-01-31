using EntityLayer.Concrete;

namespace WebUI.Models
{
    public class OutputModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int UserId { get; set; }
        public AppUser? User { get; set; }
    }
}
