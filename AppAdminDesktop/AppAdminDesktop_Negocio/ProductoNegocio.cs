using AppAdminDesktop_Datos;
using Norah_API.Models.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAdminDesktop_Negocio
{
    public class ProductoNegocio
    {
        public static ProductoEntidad guardar(ProductoEntidad producto)
        {
            return ProductoDatos.guardar(producto);
        }
        public static ProductoEntidad get(int id)
        {
            return ProductoDatos.get(id);
        }
        public static List<ProductoEntidad> get()
        {
            return ProductoDatos.get();
        }
        public static List<ProductoEntidad> getByName(String name)
        {
            return ProductoDatos.getByName(name);
        }
    }
}
