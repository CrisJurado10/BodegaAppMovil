using ProductoApp.Models;
using ProductoApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductoApp.Utils
{
    class Utils
    {

        static public APIService apiservice = new APIService();

        static public List<Producto> ListaProductos = new List<Producto>()
        {
            new Producto{


                ProductoId=1,
                Nombre="Producto 1",
                Descripcion="Descripcion 1",
                CtdenStock=1
            },

            new Producto{
                ProductoId=2,
                Nombre = "Producto 2",
                Descripcion="Descripcion 2",
                CtdenStock=2
            }

        };
    }
}
