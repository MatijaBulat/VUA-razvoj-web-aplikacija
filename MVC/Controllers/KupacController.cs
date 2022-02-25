using MVC.App_Start;
using MVC.Models;
using MVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace MVC.Controllers
{
    [Authorize]
    public class KupacController : Controller, IRequiresSessionState
    {
        //GET: Kupac
        public ActionResult Index()
        {
            var model = Repo.GetKupci();
            return View(model);
        }

        public ActionResult KupacDetails(int? id)
        {
            if (!id.HasValue || id.Value <= 0)
            {
                return RedirectToAction("Index");
            }
            var model = Repo.GetKupac(id.Value);
            return View(model);
        }

        public ActionResult RacuniKupca(int? id)
        {
            if (!id.HasValue || id.Value <= 0)
            {
                return RedirectToAction("Index");
            }
            return PartialView("_RacuniKupca", Repo.GetRacuniKupca(id.Value));
        }

        public ActionResult RacunDetails(int? id)
        {
            if (!id.HasValue || id.Value <= 0)
            {
                return RedirectToAction("Index");
            }
            RacunStavka model = new RacunStavka
            {
                Racun = Repo.GetRacun(id.Value),
                ListaStavki = (List<Stavka>)Repo.GetStavkeRacuna(id.Value)
            };
            return PartialView("_RacunDetails", model);
        }

        //[ChildActionOnly]
        public ActionResult EditKupac(int id)
        {
            //HttpCookie cookie = new HttpCookie("id");
            //cookie.Value = id.ToString();
            //cookie.Expires = DateTime.Now.AddSeconds(30);
            //Response.SetCookie(cookie);
            Session["kupac"] = Repo.GetKupac(id);
            Response.Redirect("~/KupacEdit.aspx");
            return new EmptyResult();
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