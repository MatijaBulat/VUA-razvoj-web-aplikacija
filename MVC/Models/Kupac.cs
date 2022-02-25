using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Kupac
    {
        public int IDKupac { get; set; }

        [Required(ErrorMessage = "Ime je obavezno")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Prezime je obavezno")]
        public string Prezime { get; set; }

        
        [Required(ErrorMessage = "Email je obavezan")]
        [EmailAddress(ErrorMessage = "Neispravna email adresa")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefon je obavezan")]
        public string Telefon { get; set; }

        [Display(Name = "Grad")]
        [Required(ErrorMessage = "Grad je obavezan")]
        public int GradID { get; set; }

        public Grad Grad { get; set; }
    }
}