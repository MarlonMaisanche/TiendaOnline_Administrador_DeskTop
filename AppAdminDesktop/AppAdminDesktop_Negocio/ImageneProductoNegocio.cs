using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppAdminDesktop_Datos;
using Norah_API.Models.Entidad;

namespace AppAdminDesktop_Negocio
{
    public class ImageneProductoNegocio
    {
        public static ImagenProductoEntidad add(ImagenProductoEntidad obj)
        {
            return ImagenProductoDatos.add(obj);

        }
        public static bool edit(ImagenProductoEntidad obj)
        {
            return ImagenProductoDatos.edit(obj);

        }
        public static bool delete(ImagenProductoEntidad obj)
        {
            return ImagenProductoDatos.delete(obj);

        }
        public static List<ImagenProductoEntidad> get()
        {

            return ImagenProductoDatos.get();

        }
        public static List<ImagenProductoEntidad> getByProductId(int id)
        {

            return ImagenProductoDatos.getByProductId(id);

        }
        public static ImagenProductoEntidad get(int id)
        {
            return ImagenProductoDatos.get(id);
        }
    }
}
