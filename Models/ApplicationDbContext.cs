using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace EpInForno.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
            // Costruttore 
        }

        public DbSet<ArticoloModel> Pizze { get; set; }
        public DbSet<UtenteModel> Utenti { get; set; }
        public DbSet<OrdineModel> Ordini { get; set; }
        public DbSet<DettaglioOrdineModel> DettagliOrdini { get; set; }

    }
}