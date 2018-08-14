using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WordsGame.Web.Models.Account
{    
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }    
}
