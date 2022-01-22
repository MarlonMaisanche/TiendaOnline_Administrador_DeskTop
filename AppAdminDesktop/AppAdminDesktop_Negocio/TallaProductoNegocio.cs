using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppAdminDesktop_Datos;
using Norah_API.Models.Entidad;

namespace AppAdminDesktop_Negocio
{
    public class TallaProductoNegocio
    {
        public static TallaProductoEntidad add(TallaProductoEntidad obj)
        {
            return TallaProductoDatos.add(obj);

        }
        public static bool edit(TallaProductoEntidad obj)
        {
            return TallaProductoDatos.edit(obj);

        }
        public static bool delete(TallaProductoEntidad obj)
        {
            return TallaProductoDatos.delete(obj);

        }
        public static List<TallaProductoEntidad> get()
        {

            return TallaProductoDatos.get();

        }
        public static List<TallaProductoEntidad> getByProductId(int id)
        {

            return TallaProductoDatos.getByProductId(id);

        }
        public static TallaProductoEntidad get(int id)
        {
            return TallaProductoDatos.get(id);
        }
    }
}
