using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppAdminDesktop_Datos;
using Norah_API.Models.Entidad;


namespace AppAdminDesktop_Negocio
{
    public class ColorNegocio
    {
        public static ColorEntidad add(ColorEntidad obj)
        {
            return ColorDato.add(obj);

        }
        public static bool edit(ColorEntidad obj)
        {
            return ColorDato.edit(obj);

        }
        public static bool delete(ColorEntidad obj)
        {
            return ColorDato.delete(obj);

        }
        public static List<ColorEntidad> get()
        {

            return ColorDato.get();

        }
        public static ColorEntidad get(int id)
        {
            return ColorDato.get(id);
        }
    }
}
