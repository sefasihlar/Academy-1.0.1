using EntityLayer.Concrete;
using System.ComponentModel.DataAnnotations;


namespace WebUI.Models
{
    public class RegisterModel
    {
        public int Id { get; set; }
        [StringLength(11,MinimumLength =11,ErrorMessage ="Tc Numarası 11 karakter olmalıdır")]
        [Required]
        public int TcNumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string SurName { get; set; }

        [Required]
        public int ClassId { get; set; }
        public Class Class { get; set; }

        [Required]
        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        [Required]

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage ="Şifreler uyuşmuyor")]
        [DataType(DataType.Password)]
        [Required]
        public string RePassword { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        public string? Email { get; set; }

        public string? Phone { get; set; }

    }
}
