using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Norah_API.Models.Entidad;
using System.Data.Entity.Infrastructure;

namespace AppAdminDesktop_Datos
{
    public class TipoProductoDatos
    {
        public static TipoProductoEntidad add(TipoProductoEntidad obj)
        {
            TIPO_PRODUCTO dato = new TIPO_PRODUCTO();
            dato.ID_TIPO_PRODUCTO = obj.ID_TIPO_PRODUCTO;
            dato.NOMBRE_TIPO = obj.NOMBRE_TIPO;
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    dato = ctx.TIPO_PRODUCTO.Add(dato);
                    obj.ID_TIPO_PRODUCTO = dato.ID_TIPO_PRODUCTO;
                    ctx.SaveChanges();
                }
                return obj;
            }
            catch (DbUpdateConcurrencyException)
            {
                return obj;
            }

        }
        public static bool edit(TipoProductoEntidad obj)
        {
            TIPO_PRODUCTO dato = new TIPO_PRODUCTO();
            dato.ID_TIPO_PRODUCTO = obj.ID_TIPO_PRODUCTO;
            dato.NOMBRE_TIPO = obj.NOMBRE_TIPO;
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    ctx.Entry(dato).State = System.Data.Entity.EntityState.Modified;
                    ctx.SaveChanges();
                    return true;
                }

            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

        }
        public static bool delete(TipoProductoEntidad obj)
        {
            TIPO_PRODUCTO dato = new TIPO_PRODUCTO();
            dato.ID_TIPO_PRODUCTO = obj.ID_TIPO_PRODUCTO;
            dato.NOMBRE_TIPO = obj.NOMBRE_TIPO;
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    ctx.TIPO_PRODUCTO.Remove(dato);
                    ctx.SaveChanges();
                    return true;
                }

            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

        }
        public static List<TipoProductoEntidad> get()
        {
            List<TipoProductoEntidad> lista = new List<TipoProductoEntidad>();
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var ls = ctx.TIPO_PRODUCTO.ToList();
                    foreach (var obj in ls)
                    {
                        TipoProductoEntidad dato = new TipoProductoEntidad();
                        dato.ID_TIPO_PRODUCTO = obj.ID_TIPO_PRODUCTO;
                        dato.NOMBRE_TIPO = obj.NOMBRE_TIPO;
                        lista.Add(dato);
                    }
                }
                return lista;
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }

        }
        public static TipoProductoEntidad get(int id)
        {
            TipoProductoEntidad dato = new TipoProductoEntidad();
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var obj = ctx.TIPO_PRODUCTO.Where(x => x.ID_TIPO_PRODUCTO == id).FirstOrDefault();
                    dato.ID_TIPO_PRODUCTO = obj.ID_TIPO_PRODUCTO;
                    dato.NOMBRE_TIPO = obj.NOMBRE_TIPO;

                }
                return dato;
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }

        }
    }
}
