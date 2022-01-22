using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Norah_API.Models.Entidad;
using System.Data.Entity.Infrastructure;

namespace AppAdminDesktop_Datos
{
    public class DetalleProductoDatos
    {
        public static DetalleProductoEntidad add(DetalleProductoEntidad obj)
        {
            DETALLES_PRODUCTO dato = new DETALLES_PRODUCTO();
            dato.ID_DETALLE = obj.ID_DETALLE;
            dato.ID_PROD_PER = obj.ID_PROD_PER;
            dato.TITULO = obj.TITULO;
            dato.CONTENIDO = obj.CONTENIDO;
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    dato = ctx.DETALLES_PRODUCTO.Add(dato);
                    obj.ID_DETALLE = dato.ID_DETALLE;
                    ctx.SaveChanges();
                }
                return obj;
            }
            catch (DbUpdateConcurrencyException)
            {
                return obj;
            }

        }

        public static List<DetalleProductoEntidad> getByProductId(int idPro)
        {
            List<DetalleProductoEntidad> lista = new List<DetalleProductoEntidad>();
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var ls = ctx.DETALLES_PRODUCTO.Where(x=>x.ID_PROD_PER==idPro);
                    foreach (var obj in ls)
                    {
                        DetalleProductoEntidad dato = new DetalleProductoEntidad();
                        dato.ID_DETALLE = obj.ID_DETALLE;
                        dato.ID_PROD_PER = obj.ID_PROD_PER;
                        dato.TITULO = obj.TITULO;
                        dato.CONTENIDO = obj.CONTENIDO;
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

        public static bool edit(DetalleProductoEntidad obj)
        {
            DETALLES_PRODUCTO dato = new DETALLES_PRODUCTO();
            dato.ID_DETALLE = obj.ID_DETALLE;
            dato.ID_PROD_PER = obj.ID_PROD_PER;
            dato.TITULO = obj.TITULO;
            dato.CONTENIDO = obj.CONTENIDO;
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
        public static bool delete(DetalleProductoEntidad obj)
        {
          
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var item = ctx.DETALLES_PRODUCTO.Find(obj.ID_DETALLE);
                    ctx.DETALLES_PRODUCTO.Remove(item);
                    ctx.SaveChanges();
                    return true;
                }

            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

        }
        public static List<DetalleProductoEntidad> get()
        {
            List<DetalleProductoEntidad> lista = new List<DetalleProductoEntidad>();
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var ls = ctx.DETALLES_PRODUCTO.ToList();
                    foreach (var obj in ls)
                    {
                        DetalleProductoEntidad dato = new DetalleProductoEntidad();
                        dato.ID_DETALLE = obj.ID_DETALLE;
                        dato.ID_PROD_PER = obj.ID_PROD_PER;
                        dato.TITULO = obj.TITULO;
                        dato.CONTENIDO = obj.CONTENIDO;
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
        public static DetalleProductoEntidad get(int id)
        {
            DetalleProductoEntidad dato = new DetalleProductoEntidad();
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var obj = ctx.DETALLES_PRODUCTO.Where(x => x.ID_DETALLE == id).FirstOrDefault();
                    dato.ID_DETALLE = obj.ID_DETALLE;
                    dato.ID_PROD_PER = obj.ID_PROD_PER;
                    dato.TITULO = obj.TITULO;
                    dato.CONTENIDO = obj.CONTENIDO;

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
