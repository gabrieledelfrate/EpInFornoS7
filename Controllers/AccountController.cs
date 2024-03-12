using EpInForno.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
                    var ticket = new FormsAuthenticationTicket(
                        1,
                        user.Email,
                        DateTime.Now,
                        DateTime.Now.AddMinutes(30), 
                        false,
                        user.Nome + " " + user.Cognome
                    );

                    string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                    HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    Response.Cookies.Add(authCookie);

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
