using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    [Authorize]
    public class ProizvodController : Controller
    {
        // GET: Proizvod
        public ActionResult Index()
        {
            var model = Repo.GetProizvodi();
            return View(model);
        }

        [HttpGet]
        public ActionResult EditProizvod(int? id)
        {
            if (!id.HasValue || id.Value <= 0)
            {
                return RedirectToAction("index");
            }
            Proizvod model = Repo.GetProizvod(id.Value);
            ViewBag.Potkategorije = Repo.GetPotkategorije();
            ViewBag.Boje = Repo.GetBoje();
            return View(model);
        }

        [HttpPost]
        public ActionResult EditProizvod(Proizvod p)
        {
            if (ModelState.IsValid)
            {
                Repo.UpdateProizvod(p);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("EditKategorija");
            }
        }

        public ActionResult ProizvodDetails(int? id)
        {
            if (id <= 0 || !id.HasValue)
            {
                return RedirectToAction("Index");
            }
            return View(Repo.GetProizvod(id.Value));
        }

        public ActionResult DeleteProizvod(int id)
        {
            try
            {
                Repo.DeleteProizvod(id);
                return new HttpStatusCodeResult(HttpStatusCode.OK, "Proizvod uspješno obrisan");
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Proizvod nije obrisan");
            }
        }

        [HttpGet]
        public ActionResult CreateProizvod()
        {
            ViewBag.boje = Repo.GetBoje();
            ViewBag.Potkategorije = Repo.GetPotkategorije();
            return View();
        }


        [HttpPost]
        public ActionResult CreateProizvod(Proizvod p)
        {
            if (ModelState.IsValid)
            {
                Repo.CreateProizvod(p);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("CreateProizvod");
            }
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            string action = filterContext.RouteData.Values["action"].ToString();
            Exception e = filterContext.Exception;
            filterContext.ExceptionHandled = true;
            filterContext.Result = new ViewResult()
            {
                ViewName = "Error"
            };
        }
    }
}