using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EpInForno.Models
{
    public class RegistrazioneViewModel
    {
        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Cognome { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Indirizzo { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Citta { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [EmailAddress(ErrorMessage = "Inserisci un indirizzo email valido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [DataType(DataType.Password)]
        public string PasswordUtente { get; set; }
    }

}