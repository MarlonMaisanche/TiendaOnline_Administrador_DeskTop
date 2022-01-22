using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppAdminDesktop_Datos;
using Norah_API.Models.Entidad;

namespace AppAdminDesktop_Negocio
{
   public  class GeneroNegocio
    {
        public static GeneroEntidad add(GeneroEntidad obj)
        {
            return GeneroDatos.add(obj);

        }
        public static bool edit(GeneroEntidad obj)
        {
            return GeneroDatos.edit(obj);

        }
        public static bool delete(GeneroEntidad obj)
        {
            return GeneroDatos.delete(obj);

        }
        public static List<GeneroEntidad> get()
        {

            return GeneroDatos.get();

        }
        public static GeneroEntidad get(int id)
        {
            return GeneroDatos.get(id);
        }
    }
}
