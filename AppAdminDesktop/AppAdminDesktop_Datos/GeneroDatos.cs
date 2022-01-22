using Norah_API.Models.Entidad;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAdminDesktop_Datos
{
   public  class GeneroDatos
    {
        public static GeneroEntidad add(GeneroEntidad obj)
        {
            GENERO dato = new GENERO();
            dato.ID_GENERO = obj.ID_GENERO;
            dato.GENERO1 = obj.GENERO1;
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    dato = ctx.GENERO.Add(dato);
                    obj.ID_GENERO = dato.ID_GENERO;
                    ctx.SaveChanges();
                }
                return obj;
            }
            catch (DbUpdateConcurrencyException)
            {
                return obj;
            }
          
        }
        public static bool edit(GeneroEntidad obj)
        {
            GENERO dato = new GENERO();
            dato.ID_GENERO = obj.ID_GENERO;
            dato.GENERO1 = obj.GENERO1;
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
        public static bool delete(GeneroEntidad obj)
        {
            GENERO dato = new GENERO();
            dato.ID_GENERO = obj.ID_GENERO;
            dato.GENERO1 = obj.GENERO1;
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    ctx.GENERO.Remove(dato);
                    ctx.SaveChanges();
                    return true;
                }

            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

        }
        public static List<GeneroEntidad> get()
        {
            List<GeneroEntidad> lista = new List<GeneroEntidad>();
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var ls = ctx.GENERO.ToList();
                    foreach (var obj in ls)
                    {
                        GeneroEntidad dato = new GeneroEntidad();
                        dato.ID_GENERO = obj.ID_GENERO;
                        dato.GENERO1 = obj.GENERO1;
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
        public static GeneroEntidad get(int id)
        {
            GeneroEntidad  dato = new GeneroEntidad();
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var obj = ctx.GENERO.Where(x=>x.ID_GENERO==id).FirstOrDefault();                   
                        dato.ID_GENERO = obj.ID_GENERO;
                        dato.GENERO1 = obj.GENERO1;
                        
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
