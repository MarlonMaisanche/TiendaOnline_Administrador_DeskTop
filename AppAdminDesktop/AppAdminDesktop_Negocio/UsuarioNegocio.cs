using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Norah_API.Models.Entidad;
using AppAdminDesktop_Datos;

namespace AppAdminDesktop_Negocio
{
    public  class UsuarioNegocio
    {
        public static UsuarioEntidad  add(UsuarioEntidad obj)
        {
            return UsuarioDatos.add(obj);

        }
        public static bool edit(UsuarioEntidad obj)
        {
            return UsuarioDatos.edit(obj);

        }
        public static bool delete(UsuarioEntidad obj)
        {
            return UsuarioDatos.delete(obj);

        }
        public static List<UsuarioEntidad> get()
        {

            return UsuarioDatos.get();

        }
        public static UsuarioEntidad get(int id)
        {
            return UsuarioDatos.get(id);
        }
    }
}
