using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppAdminDesktop_Datos;
using Norah_API.Models.Entidad;

namespace AppAdminDesktop_Negocio
{
    public class ImagenResenaNegocio
    {
        public static ImagenResenaEntidad add(ImagenResenaEntidad obj)
        {
            return ImagenResenaDatos.add(obj);

        }
        public static bool edit(ImagenResenaEntidad obj)
        {
            return ImagenResenaDatos.edit(obj);

        }
        public static bool delete(ImagenResenaEntidad obj)
        {
            return ImagenResenaDatos.delete(obj);

        }
        public static List<ImagenResenaEntidad> get()
        {

            return ImagenResenaDatos.get();

        }
        public static List<ImagenResenaEntidad> getByResenatID(int id)
        {

            return ImagenResenaDatos.getByResenatID(id);

        }
        public static ImagenResenaEntidad get(int id)
        {
            return ImagenResenaDatos.get(id);
        }
    }
}
