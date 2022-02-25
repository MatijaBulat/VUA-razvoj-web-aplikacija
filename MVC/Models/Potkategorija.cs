using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Potkategorija
    {
        public int IDPotkategorija { get; set; }
        public Kategorija Kategorija { get; set; }

        [Display(Name = "Kategorija")]
        [Required(ErrorMessage = "Kategorija je obavezna")]
        public int KategorijaID { get; set; }

        [Required(ErrorMessage = "Naziv potkategorije je obavezan")]
        public string Naziv { get; set; }
    }
}