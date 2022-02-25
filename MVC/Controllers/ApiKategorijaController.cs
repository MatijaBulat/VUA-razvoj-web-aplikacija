using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVC.Controllers
{
    public class ApiKategorijaController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetKategorije()
        {
            var model = Repo.GetKategorije();
            return Ok(model);
        }

        [HttpDelete]
        public IHttpActionResult DeleteKategorija(int id)
        {
            var model = Repo.GetKategorija(id);
            if (model == null)
            {
                return NotFound();
            }
            Repo.DeleteKategorija(id);
            return Ok("Kategorija je uspješno izbrisana");
        }
    }
}
