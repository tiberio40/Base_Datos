using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Base_Datos.Models
{
    public class Propiedad
    {
        [Key]
        public int ID_Propiedad { get; set; }

        [Display(Name = "Area")]
        public double Area { get; set; }

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "Debes ingresar un {0}")]
        [StringLength(30, ErrorMessage = "El campo {0} debe estar entre {2} y {1} carácteres", MinimumLength = 3)]
        public string Direccion { get; set; }

        [Display(Name = "Numero Telefonico")]
        [Required(ErrorMessage = "Debes ingresar un {0}")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Solo se admiten numero naturales")]
        public int Telefono { get; set; }

        public int ID_Usuario { get; set; }
        public virtual Usuario Usuario { get; set; }

        public virtual ICollection<Factura> Factura { get; set; }
    }
}