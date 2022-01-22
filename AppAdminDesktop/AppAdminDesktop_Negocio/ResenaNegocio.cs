using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppAdminDesktop_Datos;
using Norah_API.Models.Entidad;

namespace AppAdminDesktop_Negocio
{
    public class ResenaNegocio
    {
        public static ResenaEntidad add(ResenaEntidad obj)
        {
            return ResenasDatos.add(obj);

        }
        public static bool edit(ResenaEntidad obj)
        {
            return ResenasDatos.edit(obj);

        }
        public static bool delete(ResenaEntidad obj)
        {
            return ResenasDatos.delete(obj);

        }
        public static List<ResenaEntidad> get()
        {

            return ResenasDatos.get();

        }
        public static List<ResenaEntidad> getByProductID(int id)
        {

            return ResenasDatos.getByProductID(id);

        }
        public static ResenaEntidad get(int id)
        {
            return ResenasDatos.get(id);
        }
    }
}
