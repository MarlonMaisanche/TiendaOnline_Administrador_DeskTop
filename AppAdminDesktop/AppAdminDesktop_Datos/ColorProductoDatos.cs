using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Norah_API.Models.Entidad;
using System.Data.Entity.Infrastructure;

namespace AppAdminDesktop_Datos
{
    public class ColorProductoDatos
    {
        public static ColorProductoEntidad add(ColorProductoEntidad obj)
        {
            COLORES_PRODUCTO dato = new COLORES_PRODUCTO();
            dato.ID_COL_PRO = obj.ID_COL_PRO;
            dato.ID_PRO_PER = obj.ID_PRO_PER;
            dato.ID_COLOR = obj.ID_COLOR;
            dato.IMAGEN = obj.IMAGEN;
            dato.CANTIDAD = obj.CANTIDAD;

            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    dato = ctx.COLORES_PRODUCTO.Add(dato);
                    obj.ID_COL_PRO = dato.ID_COL_PRO;
                    ctx.SaveChanges();
                }
                return obj;
            }
            catch (DbUpdateConcurrencyException)
            {
                return obj;
            }

        }

        public static List<ColorProductoEntidad> getByProductID(int id)
        {
            List<ColorProductoEntidad> lista = new List<ColorProductoEntidad>();
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var ls = ctx.COLORES_PRODUCTO.Where(x=>x.ID_PRO_PER==id);
                    foreach (var obj in ls)
                    {
                        ColorProductoEntidad dato = new ColorProductoEntidad();
                        dato.ID_COL_PRO = obj.ID_COL_PRO;
                        dato.ID_PRO_PER = obj.ID_PRO_PER;
                        dato.ID_COLOR = obj.ID_COLOR;
                        dato.IMAGEN = obj.IMAGEN;
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

        public static bool edit(ColorProductoEntidad obj)
        {
            COLORES_PRODUCTO dato = new COLORES_PRODUCTO();
            dato.ID_COL_PRO = obj.ID_COL_PRO;
            dato.ID_PRO_PER = obj.ID_PRO_PER;
            dato.ID_COLOR = obj.ID_COLOR;
            dato.IMAGEN = obj.IMAGEN;
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
        public static bool delete(ColorProductoEntidad obj)
        {
     
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var item = ctx.COLORES_PRODUCTO.Find(obj.ID_COL_PRO);
                    ctx.COLORES_PRODUCTO.Remove(item);
                    ctx.SaveChanges();
                    return true;
                }

            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

        }
        public static List<ColorProductoEntidad> get()
        {
            List<ColorProductoEntidad> lista = new List<ColorProductoEntidad>();
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var ls = ctx.COLORES_PRODUCTO.ToList();
                    foreach (var obj in ls)
                    {
                        ColorProductoEntidad dato = new ColorProductoEntidad();
                        dato.ID_COL_PRO = obj.ID_COL_PRO;
                        dato.ID_PRO_PER = obj.ID_PRO_PER;
                        dato.ID_COLOR = obj.ID_COLOR;
                        dato.IMAGEN = obj.IMAGEN;
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
        public static ColorProductoEntidad get(int id)
        {
            ColorProductoEntidad dato = new ColorProductoEntidad();
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var obj = ctx.COLORES_PRODUCTO.Where(x => x.ID_COL_PRO == id).FirstOrDefault();
                    dato.ID_COL_PRO = obj.ID_COL_PRO;
                    dato.ID_PRO_PER = obj.ID_PRO_PER;
                    dato.ID_COLOR = obj.ID_COLOR;
                    dato.IMAGEN = obj.IMAGEN;
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
