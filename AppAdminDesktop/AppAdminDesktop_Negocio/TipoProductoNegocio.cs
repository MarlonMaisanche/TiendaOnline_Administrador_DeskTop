using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppAdminDesktop_Datos;
using Norah_API.Models.Entidad;

namespace AppAdminDesktop_Negocio
{
    public class TipoProductoNegocio
    {
        public static TipoProductoEntidad add(TipoProductoEntidad obj)
        {
            return TipoProductoDatos.add(obj);  

        }
        public static bool edit(TipoProductoEntidad obj)
        {
            return TipoProductoDatos.edit(obj);

        }
        public static bool delete(TipoProductoEntidad obj)
        {
            return TipoProductoDatos.delete(obj);

        }
        public static List<TipoProductoEntidad> get()
        {

            return TipoProductoDatos.get();

        }
        public static TipoProductoEntidad get(int id)
        {
            return TipoProductoDatos.get(id);
        }
    }
}
