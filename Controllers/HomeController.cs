using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EpInForno.Models;

namespace EpInForno.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public HomeController()
        {
            dbContext = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var articoli = dbContext.Articoli.ToList();
            return View(articoli);
        }
    }
}
