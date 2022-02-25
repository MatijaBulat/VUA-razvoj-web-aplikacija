using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    [Authorize]
    public class PotkategorijaController : Controller
    {
        // GET: Potkategorija
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreatePotkategorija()
        {
            ViewBag.Kategorije = Repo.GetKategorije();
            return View();
        }

        [HttpPost]
        public ActionResult CreatePotkategorija(Potkategorija p)
        {
            if (ModelState.IsValid)
            {
                Repo.CreatePotategorija(p);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("CreatePotkategorija");
            }
        }

        [HttpGet]
        public ActionResult EditPotkategorija(int? id)
        {
            if (!id.HasValue || id.Value <= 0)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Kategorije = Repo.GetKategorije();
            Potkategorija model = Repo.GetPotkategorija(id.Value);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditPotkategorija(Potkategorija p)
        {
            if (ModelState.IsValid)
            {
                Repo.UpdatePotkategorija(p);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("EditPotkategorija");
            }
        }

        [HttpGet]
        public ActionResult PotkategorijaDetails(int? id)
        {
            if (!id.HasValue|| id.Value <= 0)
            {
                return RedirectToAction("index");
            }
            return View(Repo.GetPotkategorija(id.Value));
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