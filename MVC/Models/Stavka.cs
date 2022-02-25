using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Stavka
    {
        public int IDStavka { get; set; }
        public int RacunID { get; set; }
        public Racun Racun { get; set; }
        public int Kolicina { get; set; }
        public int ProizvodID { get; set; }
        public Proizvod Proizvod { get; set; }
        public double CijenaPoKomadu { get; set; }
        public double PopustUPostocima { get; set; }
        public double UkupnaCijena { get; set; }
    }
}