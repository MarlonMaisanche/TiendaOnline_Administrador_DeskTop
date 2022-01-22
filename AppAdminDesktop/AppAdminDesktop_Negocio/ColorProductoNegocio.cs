using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppAdminDesktop_Datos;
using Norah_API.Models.Entidad;

namespace AppAdminDesktop_Negocio
{
   public  class ColorProductoNegocio
    {
        public static ColorProductoEntidad add(ColorProductoEntidad obj)
        {
            return ColorProductoDatos.add(obj);

        }
        public static bool edit(ColorProductoEntidad obj)
        {
            return ColorProductoDatos.edit(obj);

        }
        public static bool delete(ColorProductoEntidad obj)
        {
            return ColorProductoDatos.delete(obj);

        }
        public static List<ColorProductoEntidad> get()
        {

            return ColorProductoDatos.get();

        }
        public static List<ColorProductoEntidad> getByProductID(int id)
        {

            return ColorProductoDatos.getByProductID(id);

        }
        public static ColorProductoEntidad get(int id)
        {
            return ColorProductoDatos.get(id);
        }
    }
}
