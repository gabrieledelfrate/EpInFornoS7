using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EpInForno.Models;
using Microsoft.AspNet.Identity;

namespace EpInForno.Controllers
{
    public class CarrelloController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public CarrelloController()
        {
            dbContext = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            List<DettaglioOrdineModel> dettaglioOrdine = Session["Carrello"] as List<DettaglioOrdineModel> ?? new List<DettaglioOrdineModel>();
            ViewBag.IndirizzoUtente = GetIndirizzoUtenteLoggato();
            return View(dettaglioOrdine);
        }

        [HttpPost]
        public ActionResult AggiungiAlCarrello(int id, int quantita)
        {
            var articolo = dbContext.Articoli.FirstOrDefault(a => a.Id == id);
            if (articolo != null)
            {
                DettaglioOrdineModel dettaglioOrdine = new DettaglioOrdineModel
                {
                    ArticoloModelId = articolo.Id,
                    ArticoloModelNome = articolo.Nome,
                    ArticoloModelFoto = articolo.Foto,
                    ArticoloModelPrezzo = articolo.Prezzo,
                    Quantita = quantita,
                    PrezzoTotale = articolo.Prezzo * quantita,
                    DataOrdine = DateTime.Now
                };

                List<DettaglioOrdineModel> carrello = Session["Carrello"] as List<DettaglioOrdineModel> ?? new List<DettaglioOrdineModel>();
                carrello.Add(dettaglioOrdine);
                Session["Carrello"] = carrello;
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult AggiornaQuantita(string id, int quantita)
        {
            List<DettaglioOrdineModel> carrello = Session["Carrello"] as List<DettaglioOrdineModel>;
            if (carrello != null)
            {
                var dettaglioOrdine = carrello.FirstOrDefault(d => d.Id == id);
                if (dettaglioOrdine != null)
                {
                    dettaglioOrdine.Quantita = quantita;
                    dettaglioOrdine.PrezzoTotale = dettaglioOrdine.ArticoloModelPrezzo * quantita;

                    Session["Carrello"] = carrello;
                }
            }

            return RedirectToAction("Index");
        }

        private string GetIndirizzoUtenteLoggato()
        {
            string userEmail = User.Identity.Name;
            var utente = dbContext.Utenti.FirstOrDefault(u => u.Email == userEmail);
            if (utente != null)
            {
                return utente.Indirizzo;
            }
            return string.Empty;
        }

        [HttpPost]
        public ActionResult ProcediAllOrdine(string indirizzoSpedizione, string note)
        {
            var userId = User.Identity.GetUserId();

            List<DettaglioOrdineModel> carrello = Session["Carrello"] as List<DettaglioOrdineModel>;

            decimal prezzoTotaleOrdine = carrello.Sum(item => item.PrezzoTotale);

            OrdineModel nuovoOrdine = new OrdineModel
            {
                DettaglioOrdineId = 0,
                StatoOrdine = "In attesa di elaborazione",
                Quantita = carrello.Sum(item => item.Quantita),
                DettaglioOrdineDataOrdine = DateTime.Now,
                DettaglioOrdinePrezzoTotale = prezzoTotaleOrdine
            };

            dbContext.Ordini.Add(nuovoOrdine);
            dbContext.SaveChanges();

            int nuovoOrdineId = nuovoOrdine.Id;

            foreach (var dettaglio in carrello)
            {
                dettaglio.UtenteModelId = int.Parse(userId);


                dettaglio.Id = Guid.NewGuid().ToString();

                dettaglio.DettaglioOrdineId = nuovoOrdineId;

                dettaglio.DataOrdine = DateTime.Now;
                dettaglio.IndirizzoSpedizione = indirizzoSpedizione;
                dettaglio.Note = note;
                dettaglio.PrezzoTotaleOrdine = prezzoTotaleOrdine;

                dbContext.DettagliOrdini.Add(dettaglio);
            }

            Session["Carrello"] = null;

            dbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult RimuoviDalCarrello(string id)
        {
            List<DettaglioOrdineModel> carrello = Session["Carrello"] as List<DettaglioOrdineModel>;
            if (carrello != null)
            {
                var dettaglioOrdine = carrello.FirstOrDefault(d => d.Id == id);
                if (dettaglioOrdine != null)
                {
                    carrello.Remove(dettaglioOrdine);
                    Session["Carrello"] = carrello;
                }
            }

            return RedirectToAction("Index");
        }
    }
}
