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
    public class KategorijaController : Controller
    {
        //Get: Kategorija
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult KategorijaDetails(int? id)
        {
            if (!id.HasValue || id.Value <= 0)
            { 
                return RedirectToAction("Index");
            }
            return View(Repo.GetKategorija(id.Value));
        }

        [HttpGet]
        public ActionResult EditKategorija(int? id)
        {
            if (!id.HasValue || id.Value <= 0)
            {
                return RedirectToAction("Index");
            }
            Kategorija model = Repo.GetKategorija(id.Value);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditKategorija(Kategorija k)
        {
            if (ModelState.IsValid)
            {
                Repo.UpdateKategorija(k);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("EditKategorija");
            }
        }


        [HttpGet]
        public ActionResult CreateKategorija()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateKategorija(Kategorija k)
        {
            if (ModelState.IsValid)
            {
                Repo.CreateKategorija(k);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("CreateKategorija");
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