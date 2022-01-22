using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppAdminDesktop_Datos;
using Norah_API.Models.Entidad;

namespace AppAdminDesktop_Negocio
{
    public class TagNegocio
    {
        public static TagEntidad add(TagEntidad obj)
        {
            return TagDatos.add(obj);

        }
        public static bool edit(TagEntidad obj)
        {
            return TagDatos.edit(obj);

        }
        public static bool delete(TagEntidad obj)
        {
            return TagDatos.delete(obj);

        }
        public static List<TagEntidad> get()
        {

            return TagDatos.get();

        }
        public static List<TagEntidad> getByProductID(int id)
        {

            return TagDatos.getByProductID(id);

        }
        public static TagEntidad get(int id)
        {
            return TagDatos.get(id);
        }
    }
}
