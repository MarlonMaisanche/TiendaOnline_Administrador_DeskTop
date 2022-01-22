using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppAdminDesktop_Datos;
using Norah_API.Models.Entidad;

namespace AppAdminDesktop_Negocio
{
   public  class TallaNegocio
    {
        public static TallaEntidad add(TallaEntidad obj)
        {
            return TallaDatos.add(obj);

        }
        public static bool edit(TallaEntidad obj)
        {
            return TallaDatos.edit(obj);

        }
        public static bool delete(TallaEntidad obj)
        {
            return TallaDatos.delete(obj);

        }
        public static List<TallaEntidad> get()
        {

            return TallaDatos.get();

        }
        public static TallaEntidad get(int id)
        {
            return TallaDatos.get(id);
        }
    }
}
