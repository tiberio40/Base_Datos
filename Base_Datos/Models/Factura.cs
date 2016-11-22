using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Base_Datos.Models
{
    public class Factura
    {
        [Key]
        [Display(Name = "Factura Numero")]
        public int ID_Factura { get; set; }

        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        [Display(Name = "Costo Administracion")]
        [Required(ErrorMessage = "Debes ingresar un Valor")]
        public double Administracion { get; set; }

        [Display(Name = "Valor Final")]
        public double ValorFinal { get; set; }

        [Display(Name = "Fecha Pagada")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaPago { get; set; }

        [Display(Name = "Estado del Pago")]
        public bool EstadoPago { get; set; }


        public int ID_Propiedad { get; set; }
        public virtual Propiedad Propiedad { get; set; }

        public virtual ICollection<Cuota_Extra> Cuota_Extra { get; set; }

    }
}