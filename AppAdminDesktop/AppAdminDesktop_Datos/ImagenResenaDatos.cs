using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Norah_API.Models.Entidad;
using System.Data.Entity.Infrastructure;

namespace AppAdminDesktop_Datos
{
    public class ImagenResenaDatos
    {
        public static ImagenResenaEntidad add(ImagenResenaEntidad obj)
        {
            IMAGENES_RESENA dato = new IMAGENES_RESENA();
            dato.ID_IMA_RES = obj.ID_IMA_RES;
            dato.ID_RES_PER = obj.ID_RES_PER;
            dato.IMAGE = obj.IMAGE;

            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    dato = ctx.IMAGENES_RESENA.Add(dato);
                    obj.ID_IMA_RES = dato.ID_IMA_RES;
                    ctx.SaveChanges();
                }
                return obj;
            }
            catch (DbUpdateConcurrencyException)
            {
                return obj;
            }

        }

        public static List<ImagenResenaEntidad> getByResenatID(int id)
        {
            List<ImagenResenaEntidad> lista = new List<ImagenResenaEntidad>();
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var ls = ctx.IMAGENES_RESENA.Where(x=>x.ID_RES_PER==id);
                    foreach (var obj in ls)
                    {
                        ImagenResenaEntidad dato = new ImagenResenaEntidad();
                        dato.ID_IMA_RES = obj.ID_IMA_RES;
                        dato.ID_RES_PER = obj.ID_RES_PER;
                        dato.IMAGE = obj.IMAGE;
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

        public static bool edit(ImagenResenaEntidad obj)
        {
            IMAGENES_RESENA dato = new IMAGENES_RESENA();
            dato.ID_IMA_RES = obj.ID_IMA_RES;
            dato.ID_RES_PER = obj.ID_RES_PER;
            dato.IMAGE = obj.IMAGE;
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
        public static bool delete(ImagenResenaEntidad obj)
        {

            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var item = ctx.IMAGENES_RESENA.Find(obj.ID_IMA_RES);
                    ctx.IMAGENES_RESENA.Remove(item);
                    ctx.SaveChanges();
                    return true;
                }

            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

        }
        public static List<ImagenResenaEntidad> get()
        {
            List<ImagenResenaEntidad> lista = new List<ImagenResenaEntidad>();
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var ls = ctx.IMAGENES_RESENA.ToList();
                    foreach (var obj in ls)
                    {
                        ImagenResenaEntidad dato = new ImagenResenaEntidad();
                        dato.ID_IMA_RES = obj.ID_IMA_RES;
                        dato.ID_RES_PER = obj.ID_RES_PER;
                        dato.IMAGE = obj.IMAGE;
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
        public static ImagenResenaEntidad get(int id)
        {
            ImagenResenaEntidad dato = new ImagenResenaEntidad();
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var obj = ctx.IMAGENES_RESENA.Where(x => x.ID_IMA_RES == id).FirstOrDefault();
                    dato.ID_IMA_RES = obj.ID_IMA_RES;
                    dato.ID_RES_PER = obj.ID_RES_PER;
                    dato.IMAGE = obj.IMAGE;

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
