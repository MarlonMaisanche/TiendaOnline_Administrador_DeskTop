using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Norah_API.Models.Entidad;
using System.Data.Entity.Infrastructure;

namespace AppAdminDesktop_Datos
{
    public class CategoriaDatos
    {
        public static CategoriasEntidad add(CategoriasEntidad obj)
        {
            CATEGORIAS dato = new CATEGORIAS();
            dato.ID_CATEGORIA = obj.ID_CATEGORIA;
            dato.NOM_CATEGORIA = obj.NOM_CATEGORIA;
            dato.IMAGEN = obj.IMAGEN;
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    dato = ctx.CATEGORIAS.Add(dato);
                    obj.ID_CATEGORIA = dato.ID_CATEGORIA;
                    ctx.SaveChanges();
                }
                return obj;
            }
            catch (DbUpdateConcurrencyException)
            {
                return obj;
            }

        }
        public static bool edit(CategoriasEntidad obj)
        {
            CATEGORIAS dato = new CATEGORIAS();
            dato.ID_CATEGORIA = obj.ID_CATEGORIA;
            dato.NOM_CATEGORIA = obj.NOM_CATEGORIA;
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
        public static bool delete(CategoriasEntidad obj)
        {
            CATEGORIAS dato = new CATEGORIAS();
            dato.ID_CATEGORIA = obj.ID_CATEGORIA;
            dato.NOM_CATEGORIA = obj.NOM_CATEGORIA;
            dato.IMAGEN = obj.IMAGEN;
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    ctx.CATEGORIAS.Remove(dato);
                    ctx.SaveChanges();
                    return true;
                }

            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

        }
        public static List<CategoriasEntidad> get()
        {
            List<CategoriasEntidad> lista = new List<CategoriasEntidad>();
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var ls = ctx.CATEGORIAS.ToList();
                    foreach (var obj in ls)
                    {
                        CategoriasEntidad dato = new CategoriasEntidad();
                        dato.ID_CATEGORIA = obj.ID_CATEGORIA;
                        dato.NOM_CATEGORIA = obj.NOM_CATEGORIA;
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
        public static CategoriasEntidad get(int id)
        {
            CategoriasEntidad dato = new CategoriasEntidad();
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var obj = ctx.CATEGORIAS.Where(x => x.ID_CATEGORIA == id).FirstOrDefault();
                    dato.ID_CATEGORIA = obj.ID_CATEGORIA;
                    dato.NOM_CATEGORIA = obj.NOM_CATEGORIA;
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
