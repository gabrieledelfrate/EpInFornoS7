using EpInForno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EpInForno.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationDbContext dbContext;

        public AccountController()
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
                var user = dbContext.Utenti.FirstOrDefault(u => u.Email == model.Email && u.PasswordUtente == model.Password);
                if (user != null)
                {
                    return RedirectToAction("Index", "Home"); 
                }
                else
                {
                    ModelState.AddModelError("", "Credenziali non valide. Riprova.");
                }
            }

            return View(model);
        }
    }
}