﻿using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class ResetPasswordModel
    {

        [Required]
        public string Token { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
