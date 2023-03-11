using EntityLayer.Concrete;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class AuthorityModel
    {
        public int Id { get; set; }
        [Required]
        public string TcNumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string SurName { get; set; }

        [Required]
        public int ClassId { get; set; }
        public Class Class { get; set; }

        [Required]

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password)]

        public string? Email { get; set; }
        public bool Authority { get; set; }

        public string? Phone { get; set; }
    }
}
