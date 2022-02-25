using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVC.Controllers
{
    public class ApiKupacController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetKupci()
        {
            var model = Repo.GetKupci();
            return Ok(model);
        }
    }
}
