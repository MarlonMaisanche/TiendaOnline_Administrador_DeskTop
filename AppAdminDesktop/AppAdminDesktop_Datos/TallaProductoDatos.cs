using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Norah_API.Models.Entidad;
using System.Data.Entity.Infrastructure;
namespace AppAdminDesktop_Datos
{
    public class TallaProductoDatos
    {
        public static TallaProductoEntidad add(TallaProductoEntidad obj)
        {
            TALLAS_PRODUCTO dato = new TALLAS_PRODUCTO();
            dato.ID_TALL_PRO = obj.ID_TALL_PRO;
            dato.ID_PRO_PER = obj.ID_PRO_PER;
            dato.ID_TALLA_PER = obj.ID_TALLA_PER;
            dato.PRECIO_TALL = obj.PRECIO_TALL;
            dato.PRECIO_TALL_PROM = obj.PRECIO_TALL_PROM;
            dato.CANTIDAD = obj.CANTIDAD;
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    dato = ctx.TALLAS_PRODUCTO.Add(dato);
                    obj.ID_TALL_PRO = dato.ID_TALL_PRO;
                    ctx.SaveChanges();
                }
                return obj;
            }
            catch (DbUpdateConcurrencyException)
            {
                return obj;
            }

        }

        public static List<TallaProductoEntidad> getByProductId(int id)
        {
            List<TallaProductoEntidad> lista = new List<TallaProductoEntidad>();
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var ls = ctx.TALLAS_PRODUCTO.Where(x=>x.ID_PRO_PER==id);
                    foreach (var obj in ls)
                    {
                        TallaProductoEntidad dato = new TallaProductoEntidad();
                        dato.ID_TALL_PRO = obj.ID_TALL_PRO;
                        dato.ID_PRO_PER = obj.ID_PRO_PER;
                        dato.ID_TALLA_PER = obj.ID_TALLA_PER;
                        dato.PRECIO_TALL = obj.PRECIO_TALL;
                        dato.PRECIO_TALL_PROM = obj.PRECIO_TALL_PROM;
                        dato.CANTIDAD = obj.CANTIDAD;
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

        public static bool edit(TallaProductoEntidad obj)
        {
            TALLAS_PRODUCTO dato = new TALLAS_PRODUCTO();
            dato.ID_TALL_PRO = obj.ID_TALL_PRO;
            dato.ID_PRO_PER = obj.ID_PRO_PER;
            dato.ID_TALLA_PER = obj.ID_TALLA_PER;
            dato.PRECIO_TALL = obj.PRECIO_TALL;
            dato.PRECIO_TALL_PROM = obj.PRECIO_TALL_PROM;
            dato.CANTIDAD = obj.CANTIDAD;
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
        public static bool delete(TallaProductoEntidad obj)
        {
           
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var item = ctx.TALLAS_PRODUCTO.Find(obj.ID_TALL_PRO);
                    ctx.TALLAS_PRODUCTO.Remove(item);
                    ctx.SaveChanges();
                    return true;
                }

            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

        }
        public static List<TallaProductoEntidad> get()
        {
            List<TallaProductoEntidad> lista = new List<TallaProductoEntidad>();
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var ls = ctx.TALLAS_PRODUCTO.ToList();
                    foreach (var obj in ls)
                    {
                        TallaProductoEntidad dato = new TallaProductoEntidad();
                        dato.ID_TALL_PRO = obj.ID_TALL_PRO;
                        dato.ID_PRO_PER = obj.ID_PRO_PER;
                        dato.ID_TALLA_PER = obj.ID_TALLA_PER;
                        dato.PRECIO_TALL = obj.PRECIO_TALL;
                        dato.PRECIO_TALL_PROM = obj.PRECIO_TALL_PROM;
                        dato.CANTIDAD = obj.CANTIDAD;
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
        public static TallaProductoEntidad get(int id)
        {
            TallaProductoEntidad dato = new TallaProductoEntidad();
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var obj = ctx.TALLAS_PRODUCTO.Where(x => x.ID_TALL_PRO == id).FirstOrDefault();
                    dato.ID_TALL_PRO = obj.ID_TALL_PRO;
                    dato.ID_PRO_PER = obj.ID_PRO_PER;
                    dato.ID_TALLA_PER = obj.ID_TALLA_PER;
                    dato.PRECIO_TALL = obj.PRECIO_TALL;
                    dato.PRECIO_TALL_PROM = obj.PRECIO_TALL_PROM;
                    dato.CANTIDAD = obj.CANTIDAD;

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
