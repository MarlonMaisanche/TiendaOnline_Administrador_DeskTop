using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Norah_API.Models.Entidad;
using System.Data.Entity.Infrastructure;
namespace AppAdminDesktop_Datos
{
    public class TagDatos
    {
        public static TagEntidad add(TagEntidad obj)
        {
            TAGS dato = new TAGS();
            dato.ID_TAG = obj.ID_TAG;
            dato.ID_PRO_PER = obj.ID_PRO_PER;
            dato.TAG = obj.TAG;
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    dato = ctx.TAGS.Add(dato);
                    obj.ID_TAG = dato.ID_TAG;
                    ctx.SaveChanges();
                }
                return obj;
            }
            catch (DbUpdateConcurrencyException)
            {
                return obj;
            }

        }

        public static List<TagEntidad> getByProductID(int id)
        {
            List<TagEntidad> lista = new List<TagEntidad>();
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var ls = ctx.TAGS.Where(x=>x.ID_PRO_PER==id);
                    foreach (var obj in ls)
                    {
                        TagEntidad dato = new TagEntidad();
                        dato.ID_TAG = obj.ID_TAG;
                        dato.ID_PRO_PER = obj.ID_PRO_PER;
                        dato.TAG = obj.TAG;
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

        public static bool edit(TagEntidad obj)
        {
            TAGS dato = new TAGS();
            dato.ID_TAG = obj.ID_TAG;
            dato.ID_PRO_PER = obj.ID_PRO_PER;
            dato.TAG = obj.TAG;
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
        public static bool delete(TagEntidad obj)
        {
            TAGS dato = new TAGS();
            dato.ID_TAG = obj.ID_TAG;
            dato.ID_PRO_PER = obj.ID_PRO_PER;
            dato.TAG = obj.TAG;
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    ctx.TAGS.Remove(dato);
                    ctx.SaveChanges();
                    return true;
                }

            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

        }
        public static List<TagEntidad> get()
        {
            List<TagEntidad> lista = new List<TagEntidad>();
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var ls = ctx.TAGS.ToList();
                    foreach (var obj in ls)
                    {
                        TagEntidad dato = new TagEntidad();
                        dato.ID_TAG = obj.ID_TAG;
                        dato.ID_PRO_PER = obj.ID_PRO_PER;
                        dato.TAG = obj.TAG;
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
        public static TagEntidad get(int id)
        {
            TagEntidad dato = new TagEntidad();
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var obj = ctx.TAGS.Where(x => x.ID_TAG == id).FirstOrDefault();
                    dato.ID_TAG = obj.ID_TAG;
                    dato.ID_PRO_PER = obj.ID_PRO_PER;
                    dato.TAG = obj.TAG;

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
