using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Base_Datos.Models
{
    public class Telefono
    {
        [Key]
        public int ID_Telefono { get; set; }

        [Display(Name = "Numero de Telefono")]
        [Required(ErrorMessage = "Debes ingresar un {0}")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Debes Ingresar un numero natural")]
        public string NoTelefonico { get; set; }

        public int ID_Usuario { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}