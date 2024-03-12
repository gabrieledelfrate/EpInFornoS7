using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpInForno.Models
{
    public class AmministratoreModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Matricola { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}