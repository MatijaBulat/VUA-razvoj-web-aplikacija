using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Proizvod
    {
        public int IDProizvod { get; set; }

        [Required(ErrorMessage = "Naziv je obavezan")]
        public string Naziv { get; set; }

        [Display(Name = "Broj proizvoda")]
        [Required(ErrorMessage = "Broj proizvoda je obavezan")]
        public string BrojProizvoda { get; set; }

        public string Boja { get; set; }

        [Display(Name = "Minimalna kolicina na skladistu")]
        [Required(ErrorMessage = "Količina je obavezna")]
        [Range(0, int.MaxValue, ErrorMessage = "Dozvoljeni su samo pozitivni brojevi")]
        public int MinimalnaKolicinaNaSkladistu { get; set; }

        [Display(Name = "Cijena bez PDV-a")]
        [Required(ErrorMessage = "Cijena je obavezna")]
        public double CijenaBezPDV { get; set; }

        [Display(Name = "Potkategorija")]
        public int PotkategorijaID { get; set; }

        public Potkategorija Potkategorija { get; set; }
    }
}