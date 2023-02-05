using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class ResetPasswordModel
    {

        public string Token { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
