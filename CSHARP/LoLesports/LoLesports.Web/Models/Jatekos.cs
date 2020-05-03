using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoLesports.Web.Models
{
    public class Jatekos
    {
        [Display(Name ="Felhasználónév")]
        [Required]
        public string Felhasznalonev { get; set; }

        [Display(Name = "Vezetéknév")]
        [Required]
        public string Vezeteknev { get; set; }

        [Display(Name = "Keresztnév")]
        [Required]
        public string Keresztnev { get; set; }

        [Display(Name = "Életkor")]
        public Nullable<int> Eletkor { get; set; }

        [Display(Name = "Pozíció")]
        [Required]
        public string Pozicio { get; set; }

        [Display(Name = "Nemzetiség")]
        [Required]
        public string Nemzetiseg { get; set; }

        [Display(Name = "Csapatnév")]
        [Required]
        public string Csapatnev { get; set; }
    }
}