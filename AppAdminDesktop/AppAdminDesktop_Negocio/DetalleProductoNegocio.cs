using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppAdminDesktop_Datos;
using Norah_API.Models.Entidad;

namespace AppAdminDesktop_Negocio
{
    public class DetalleProductoNegocio
    {
        public static DetalleProductoEntidad add(DetalleProductoEntidad obj)
        {
        
            return DetalleProductoDatos.add(obj);

        }
        public static bool edit(DetalleProductoEntidad obj)
        {
            return DetalleProductoDatos.edit(obj);

        }
        public static bool delete(DetalleProductoEntidad obj)
        {
            return DetalleProductoDatos.delete(obj);

        }
        public static List<DetalleProductoEntidad> get()
        {

            return DetalleProductoDatos.get();

        }
        public static List<DetalleProductoEntidad> getByProductId(int idPro)
        {

            return DetalleProductoDatos.getByProductId(idPro);

        }
        public static DetalleProductoEntidad get(int id)
        {
            return DetalleProductoDatos.get(id);
        }
    }
}
