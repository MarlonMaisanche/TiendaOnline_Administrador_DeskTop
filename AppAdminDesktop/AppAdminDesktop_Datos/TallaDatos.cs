using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Norah_API.Models.Entidad;
using System.Data.Entity.Infrastructure;

namespace AppAdminDesktop_Datos
{
    public class TallaDatos
    {
        public static TallaEntidad add(TallaEntidad obj)
        {
            TALLAS dato = new TALLAS();
            dato.ID_TALLA = obj.ID_TALLA;
            dato.NOM_TALLA = obj.NOM_TALLA;

            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    dato = ctx.TALLAS.Add(dato);
                    obj.ID_TALLA = dato.ID_TALLA;
                    ctx.SaveChanges();
                }
                return obj;
            }
            catch (DbUpdateConcurrencyException)
            {
                return obj;
            }

        }
        public static bool edit(TallaEntidad obj)
        {
            TALLAS dato = new TALLAS();
            dato.ID_TALLA = obj.ID_TALLA;
            dato.NOM_TALLA = obj.NOM_TALLA;
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
        public static bool delete(TallaEntidad obj)
        {
  
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var item = ctx.TALLAS.Find(obj.ID_TALLA);
                    ctx.TALLAS.Remove(item);
                    ctx.SaveChanges();
                    return true;
                }

            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

        }
        public static List<TallaEntidad> get()
        {
            List<TallaEntidad> lista = new List<TallaEntidad>();
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var ls = ctx.TALLAS.ToList();
                    foreach (var obj in ls)
                    {
                        TallaEntidad dato = new TallaEntidad();
                        dato.ID_TALLA = obj.ID_TALLA;
                        dato.NOM_TALLA = obj.NOM_TALLA;
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
        public static TallaEntidad get(int id)
        {
            TallaEntidad dato = new TallaEntidad();
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var obj = ctx.TALLAS.Where(x => x.ID_TALLA == id).FirstOrDefault();
                    dato.ID_TALLA = obj.ID_TALLA;
                    dato.NOM_TALLA = obj.NOM_TALLA;

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
