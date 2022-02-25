using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models.ViewModel
{
    public class RacunStavka
    {
        public Racun Racun { get; set; }
        public List<Stavka> ListaStavki { get; set; }
    }
}