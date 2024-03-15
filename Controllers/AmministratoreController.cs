using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using EpInForno.Models;

namespace EpInForno.Controllers
{
    public class AmministratoreController : Controller
    {
        private ApplicationDbContext dbContext;

        public AmministratoreController()
        {
            dbContext = new ApplicationDbContext();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var amministratore = dbContext.Amministratori.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

                if (amministratore != null)
                {
                    var ticket = new FormsAuthenticationTicket(
                        1,
                        amministratore.Email,
                        DateTime.Now,
                        DateTime.Now.AddMinutes(30),
                        false,
                        amministratore.Nome + " " + amministratore.Cognome
                    );

                    string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                    HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    Response.Cookies.Add(authCookie);

                    return RedirectToAction("ListaOrdini", "Amministratore");
                }
                else
                {
                    ModelState.AddModelError("", "Credenziali non valide. Riprova.");
                }
            }

            return View(model);
        }
        [Authorize]
        [HttpPost]
        public ActionResult ModificaStatoOrdine(int id, string statoOrdine)
        {
            var ordine = dbContext.Ordini.FirstOrDefault(o => o.Id == id);
            if (ordine != null)
            {
                ordine.StatoOrdine = statoOrdine;
                dbContext.SaveChanges();
                return RedirectToAction("ListaOrdini");
            }
            else
            {
                ModelState.AddModelError("", "Ordine non trovato.");
                return View("Error");
            }
        }

        public ActionResult OrdiniEvasi()
        {
            var ordiniEvasi = dbContext.Ordini.Where(o => o.StatoOrdine == "evaso").ToList();
            return View(ordiniEvasi);
        }

        public ActionResult IncassoTotale()
        {
            DateTime oggi = DateTime.Today;

            decimal sommaPrezzoTotale = dbContext.Ordini
                .Where(o => o.DettaglioOrdineDataOrdine.Date == oggi)
                .Sum(o => o.DettaglioOrdinePrezzoTotale);

            return View(sommaPrezzoTotale);
        }


    }
}