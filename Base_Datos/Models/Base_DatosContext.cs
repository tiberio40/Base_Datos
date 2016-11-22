using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Base_Datos.Models
{
    public class Base_DatosContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Base_DatosContext() : base("name=Base_DatosContext")
        {
        }

        public System.Data.Entity.DbSet<Base_Datos.Models.Usuario> Usuarios { get; set; }

        public System.Data.Entity.DbSet<Base_Datos.Models.Telefono> Telefonoes { get; set; }

        public System.Data.Entity.DbSet<Base_Datos.Models.Propiedad> Propiedads { get; set; }

        public System.Data.Entity.DbSet<Base_Datos.Models.Factura> Facturas { get; set; }

        public System.Data.Entity.DbSet<Base_Datos.Models.Cuota_Extra> Cuota_Extra { get; set; }
    }
}
