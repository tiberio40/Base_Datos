using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Base_Datos.Models
{
    public class Cuota_Extra
    {
        [Key]
        public int ID_Couta_Extra { get; set; }

        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        [Display(Name = "Valor ")]
        [Required(ErrorMessage = "Debes ingresar un Valor")]
        public double Valor { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Debes ingresar un {0}")]
        [StringLength(30, ErrorMessage = "El campo {0} debe estar entre {2} y {1} carácteres", MinimumLength = 3)]
        public string Descripcion { get; set; }

        public int ID_Factura { get; set; }
        public virtual Factura Factura { get; set; }
    }
}