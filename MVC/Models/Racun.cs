using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Racun
    {
        public int IDRacun { get; set; }
        [Display(Name = "Datum izdavanja")]
        public DateTime DatumIzdavanja { get; set; }
        [Display(Name = "Broj racuna")]
        public string BrojRacuna { get; set; }
        public int KupacID { get; set; }

        [Display(Name = "Komercijalist")]
        public int KomercijalistID { get; set; }
        public Komercijalist Komercijalist { get; set; }

        [Display(Name = "Kreditna kartica")]
        public int KreditnaKarticaID { get; set; }
        public KreditnaKartica KreditnaKartica { get; set; }

        public string Komentar { get; set; }

    }
}