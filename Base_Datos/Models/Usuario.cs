using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Base_Datos.Models
{
    public class Usuario
    {
        [Key]
        public int ID_Usuario { get; set; }

        [Display(Name = "Nombre de Usuario")]
        [Required(ErrorMessage = "Debes ingresar un {0}")]
        [StringLength(30, ErrorMessage = "El campo {0} debe estar entre {2} y {1} carácteres", MinimumLength = 3)]
        public string Nickname { get; set; }

        [Display(Name = "Nombre y Apellido")]
        [Required(ErrorMessage = "Debes ingresar un {0}")]
        [StringLength(50, ErrorMessage = "El campo {0} debe estar entre {2} y {1} carácteres", MinimumLength = 3)]
        public string Nombre { get; set; }

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "Debes ingresar un {0}")]
        [StringLength(30, ErrorMessage = "El campo {0} debe estar entre {2} y {1} carácteres", MinimumLength = 3)]
        public string Direccion { get; set; }

        [Display(Name = "Correo Electronico")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Clave")]
        [DataType(DataType.Password)]
        [StringLength(30, ErrorMessage = "El campo {0} debe estar entre {2} y {1} carácteres", MinimumLength = 6)]
        public string Clave { get; set; }

        [Display(Name = "Tipo de Usuario")]
        public bool TipoUsuario { get; set; }

        public virtual ICollection<Propiedad> Propiedad { get; set; }

        public virtual ICollection<Telefono> Telefono { get; set; }
    }
}