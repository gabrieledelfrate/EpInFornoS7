using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpInForno.Models
{
    public class OrdineModel
    {
        public int Id { get; set; }
        public int DettaglioOrdineId { get; set; }
        public int ArticoloModelId { get; set; }
        public string StatoOrdine { get; set; }
        public int Quantita { get; set; }
        public DateTime DettaglioOrdineDataOrdine { get; set; }
        public decimal DettaglioOrdinePrezzoTotale { get; set; }
    }
}