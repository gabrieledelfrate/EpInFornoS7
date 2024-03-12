using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace EpInForno.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Campo obbligatorio")]
        [EmailAddress(ErrorMessage = "Inserisci un indirizzo email valido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}