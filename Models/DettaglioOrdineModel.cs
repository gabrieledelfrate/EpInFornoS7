using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpInForno.Models
{
    public class DettaglioOrdineModel
    {
        public string Id { get; set; } 
        public int UtenteModelId { get; set; }
        public int ArticoloModelId { get; set; }
        public string ArticoloModelNome { get; set; }
        public string ArticoloModelFoto { get; set; }
        public decimal ArticoloModelPrezzo { get; set; }
        public int Quantita { get; set; }
        public decimal PrezzoTotale { get; set; }
        public DateTime DataOrdine { get; set; }
        public string IndirizzoSpedizione { get; set; }
        public string Note { get; set; }
        public decimal PrezzoTotaleOrdine { get; set; }
        public int DettaglioOrdineId { get; set; }
        public ICollection<DettaglioOrdineModel> DettagliOrdineModel { get; set; }
    }
}

