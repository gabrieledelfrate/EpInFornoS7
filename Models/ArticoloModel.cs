using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpInForno.Models
{
    public class ArticoloModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Foto { get; set; }
        public decimal Prezzo { get; set; }
        public int TempoConsegna { get; set; }
        public string Ingredienti { get; set; }
    }
}