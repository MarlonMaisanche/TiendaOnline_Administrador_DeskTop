using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Norah_API.Models.Entidad;
using System.Data.Entity.Infrastructure;

namespace AppAdminDesktop_Datos
{
    public class ImagenProductoDatos
    {
        public static ImagenProductoEntidad add(ImagenProductoEntidad obj)
        {
            IMAGENES_PRODUCTO dato = new IMAGENES_PRODUCTO();
            dato.ID_IMAGEN = obj.ID_IMAGEN;
            dato.ID_PROD_PER = obj.ID_PROD_PER;
            dato.IMAGEN = obj.IMAGEN;
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    dato = ctx.IMAGENES_PRODUCTO.Add(dato);
                    obj.ID_IMAGEN = dato.ID_IMAGEN;
                    ctx.SaveChanges();
                }
                return obj;
            }
            catch (DbUpdateConcurrencyException)
            {
                return obj;
            }

        }

        public static List<ImagenProductoEntidad> getByProductId(int id)
        {
            List<ImagenProductoEntidad> lista = new List<ImagenProductoEntidad>();
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var ls = ctx.IMAGENES_PRODUCTO.Where(x=>x.ID_PROD_PER==id);
                    foreach (var obj in ls)
                    {
                        ImagenProductoEntidad dato = new ImagenProductoEntidad();
                        dato.ID_IMAGEN = obj.ID_IMAGEN;
                        dato.ID_PROD_PER = obj.ID_PROD_PER;
                        dato.IMAGEN = obj.IMAGEN;
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

        public static bool edit(ImagenProductoEntidad obj)
        {
            IMAGENES_PRODUCTO dato = new IMAGENES_PRODUCTO();
            dato.ID_IMAGEN = obj.ID_IMAGEN;
            dato.ID_PROD_PER = obj.ID_PROD_PER;
            dato.IMAGEN = obj.IMAGEN;
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
        public static bool delete(ImagenProductoEntidad obj)
        {
            IMAGENES_PRODUCTO dato = new IMAGENES_PRODUCTO();
            dato.ID_IMAGEN = obj.ID_IMAGEN;
            dato.ID_PROD_PER = obj.ID_PROD_PER;
            dato.IMAGEN = obj.IMAGEN;
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var del = ctx.IMAGENES_PRODUCTO.FirstOrDefault(z => z.ID_IMAGEN == obj.ID_IMAGEN);
                    ctx.IMAGENES_PRODUCTO.Remove(del);
                    ctx.SaveChanges();
                    return true;
                }

            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

        }
        public static List<ImagenProductoEntidad> get()
        {
            List<ImagenProductoEntidad> lista = new List<ImagenProductoEntidad>();
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var ls = ctx.IMAGENES_PRODUCTO.ToList();
                    foreach (var obj in ls)
                    {
                        ImagenProductoEntidad dato = new ImagenProductoEntidad();
                        dato.ID_IMAGEN = obj.ID_IMAGEN;
                        dato.ID_PROD_PER = obj.ID_PROD_PER;
                        dato.IMAGEN = obj.IMAGEN;
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
        public static ImagenProductoEntidad get(int id)
        {
            ImagenProductoEntidad dato = new ImagenProductoEntidad();
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var obj = ctx.IMAGENES_PRODUCTO.Where(x => x.ID_IMAGEN == id).FirstOrDefault();
                    dato.ID_IMAGEN = obj.ID_IMAGEN;
                    dato.ID_PROD_PER = obj.ID_PROD_PER;
                    dato.IMAGEN = obj.IMAGEN;

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
