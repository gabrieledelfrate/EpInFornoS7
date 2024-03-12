using EpInForno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EpInForno.Controllers
{
    public class RegistrazioneController : Controller
    {
        private ApplicationDbContext dbContext;

        public RegistrazioneController()
        {
            dbContext = new ApplicationDbContext();
        }

        public ActionResult Registrazione()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrazione(RegistrazioneViewModel model)
        {
            if (ModelState.IsValid)
            {
                var nuovoUtente = new UtenteModel
                {
                    Nome = model.Nome,
                    Cognome = model.Cognome,
                    Telefono = model.Telefono,
                    Indirizzo = model.Indirizzo,
                    Citta = model.Citta,
                    Email = model.Email,
                    PasswordUtente = model.PasswordUtente
                };

                dbContext.Utenti.Add(nuovoUtente);
                dbContext.SaveChanges();

                return RedirectToAction("Login", "Account");
            }

            return View(model);
        }
    }

}