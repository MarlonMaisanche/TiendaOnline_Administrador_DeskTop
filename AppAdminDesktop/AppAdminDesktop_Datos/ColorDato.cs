using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Norah_API.Models.Entidad;
using System.Data.Entity.Infrastructure;

namespace AppAdminDesktop_Datos
{
    public class ColorDato
    {
        public static ColorEntidad add(ColorEntidad obj)
        {
            COLORES dato = new COLORES();
            dato.ID_COLOR = obj.ID_COLOR;
            dato.NOM_COLOR = obj.NOM_COLOR;

            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    dato = ctx.COLORES.Add(dato);
                    obj.ID_COLOR = dato.ID_COLOR;
                    ctx.SaveChanges();
                }
                return obj;
            }
            catch (DbUpdateConcurrencyException)
            {
                return obj;
            }

        }
        public static bool edit(ColorEntidad obj)
        {
            COLORES dato = new COLORES();
            dato.ID_COLOR = obj.ID_COLOR;
            dato.NOM_COLOR = obj.NOM_COLOR;
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
        public static bool delete(ColorEntidad obj)
        {
            COLORES dato = new COLORES();
            dato.ID_COLOR = obj.ID_COLOR;
            dato.NOM_COLOR = obj.NOM_COLOR;
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    ctx.COLORES.Remove(dato);
                    ctx.SaveChanges();
                    return true;
                }

            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

        }
        public static List<ColorEntidad> get()
        {
            List<ColorEntidad> lista = new List<ColorEntidad>();
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var ls = ctx.COLORES.ToList();
                    foreach (var obj in ls)
                    {
                        ColorEntidad dato = new ColorEntidad();
                        dato.ID_COLOR = obj.ID_COLOR;
                        dato.NOM_COLOR = obj.NOM_COLOR;
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
        public static ColorEntidad get(int id)
        {
            ColorEntidad dato = new ColorEntidad();
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var obj = ctx.COLORES.Where(x => x.ID_COLOR == id).FirstOrDefault();
                    dato.ID_COLOR = obj.ID_COLOR;
                    dato.NOM_COLOR = obj.NOM_COLOR;

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
