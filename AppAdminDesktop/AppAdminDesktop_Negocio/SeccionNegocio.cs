using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppAdminDesktop_Datos;
using Norah_API.Models.Entidad;

namespace AppAdminDesktop_Negocio
{
   public class SeccionNegocio
    {
        public static SeccionEntidad add(SeccionEntidad obj)
        {
            return SeccionDatos.add(obj);

        }
        public static bool edit(SeccionEntidad obj)
        {
            return SeccionDatos.edit(obj);

        }
        public static bool delete(SeccionEntidad obj)
        {
            return SeccionDatos.delete(obj);

        }
        public static List<SeccionEntidad> get()
        {

            return SeccionDatos.get();

        }
        public static SeccionEntidad get(int id)
        {
            return SeccionDatos.get(id);
        }
    }
}
