using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppAdminDesktop_Datos;
using Norah_API.Models.Entidad;

namespace AppAdminDesktop_Negocio
{
    public class CategoriaNegocio
    {
        public static CategoriasEntidad add(CategoriasEntidad obj)
        {
            return CategoriaDatos.add(obj);

        }
        public static bool edit(CategoriasEntidad obj)
        {
            return CategoriaDatos.edit(obj);

        }
        public static bool delete(CategoriasEntidad obj)
        {
            return CategoriaDatos.delete(obj);

        }
        public static List<CategoriasEntidad> get()
        {

            return CategoriaDatos.get();

        }
        public static CategoriasEntidad get(int id)
        {
            return CategoriaDatos.get(id);
        }
    }
}
