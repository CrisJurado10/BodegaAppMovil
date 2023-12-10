using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductoApp.Models
{
   public class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int CtdenStock { get; set; }

        public string urlImage { get; set; }

        public int ProveedorId { get; set; }
    }
}
