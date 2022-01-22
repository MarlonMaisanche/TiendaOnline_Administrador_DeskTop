using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppAdminDesktop_Datos;
using Norah_API.Models.Entidad;

namespace AppAdminDesktop_Negocio
{
    public class SubcategoriaNegocio
    {
        public static SubCategoriaEntidad add(SubCategoriaEntidad obj)
        {
            return SubcategoriaDatos.add(obj);

        }
        public static bool edit(SubCategoriaEntidad obj)
        {
            return SubcategoriaDatos.edit(obj);

        }
        public static bool delete(SubCategoriaEntidad obj)
        {
            return SubcategoriaDatos.delete(obj);

        }
        public static List<SubCategoriaEntidad> get()
        {

            return SubcategoriaDatos.get();

        }
        public static SubCategoriaEntidad get(int id)
        {
            return SubcategoriaDatos.get(id);
        }
    }
}
