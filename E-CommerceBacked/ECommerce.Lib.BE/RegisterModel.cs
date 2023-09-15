using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Lib.BE
{
    public class RegisterModel
    {
       
        [Required, Column(TypeName = "nvarchar(100)")]
        public string userName { get; set; } = String.Empty;

        [Required,PasswordPropertyText, MinLength(6,ErrorMessage = "Password Length")]
        public string password { get; set; } = String.Empty;


        [Required,  Compare("password")]
        public string confirmPassword {get; set; } = String.Empty;

        public string verificationToken { get; set; } = String.Empty;

        [EmailAddress]
        public string email { get; set; } = String.Empty;

        [Phone]
        public string phone { get; set; } = String.Empty;

        public byte [] passwordHash { get; set; } = new byte [32];
        public byte [] passwordSalt {get; set; }  = new byte[32];
    }
}
