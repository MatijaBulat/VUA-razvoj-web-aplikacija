using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVC.Controllers
{
    public class ApiPotkategorijaController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetPotkategorije()
        {
            var model = Repo.GetPotkategorije();
            return Ok(model);
        }

        [HttpDelete]
        public IHttpActionResult DeletePotkategorija(int id)
        {
            var model = Repo.GetPotkategorija(id);
            if (model == null)
            {
                return NotFound();
            }
            Repo.DeletePotkategorija(id);
            return Ok("Potkategorija je uspješno izbrisana");
        }
    }
}
