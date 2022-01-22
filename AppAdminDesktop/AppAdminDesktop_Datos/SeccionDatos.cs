using Norah_API.Models.Entidad;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAdminDesktop_Datos
{
    public class SeccionDatos
    {
        public static SeccionEntidad add(SeccionEntidad obj)
        {
            SECCIONES dato = new SECCIONES();
            dato.ID_SECCION = obj.ID_SECCION;
            dato.NOMBRE_SECCION = obj.NOMBRE_SECCION;

            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    dato = ctx.SECCIONES.Add(dato);
                    obj.ID_SECCION = dato.ID_SECCION;
                    ctx.SaveChanges();
                }
                return obj;
            }
            catch (DbUpdateConcurrencyException)
            {
                return obj;
            }

        }
        public static bool edit(SeccionEntidad obj)
        {
            SECCIONES dato = new SECCIONES();
            dato.ID_SECCION = obj.ID_SECCION;
            dato.NOMBRE_SECCION = obj.NOMBRE_SECCION;
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
        public static bool delete(SeccionEntidad obj)
        {
            SECCIONES dato = new SECCIONES();
            dato.ID_SECCION = obj.ID_SECCION;
            dato.NOMBRE_SECCION = obj.NOMBRE_SECCION;
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    ctx.SECCIONES.Remove(dato);
                    ctx.SaveChanges();
                    return true;
                }

            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

        }
        public static List<SeccionEntidad> get()
        {
            List<SeccionEntidad> lista = new List<SeccionEntidad>();
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var ls = ctx.SECCIONES.ToList();
                    foreach (var obj in ls)
                    {
                        SeccionEntidad dato = new SeccionEntidad();
                        dato.ID_SECCION = obj.ID_SECCION;
                        dato.NOMBRE_SECCION = obj.NOMBRE_SECCION;
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
        public static SeccionEntidad get(int id)
        {
            SeccionEntidad dato = new SeccionEntidad();
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var obj = ctx.SECCIONES.Where(x => x.ID_SECCION == id).FirstOrDefault();
                    dato.ID_SECCION = obj.ID_SECCION;
                    dato.NOMBRE_SECCION = obj.NOMBRE_SECCION;
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
