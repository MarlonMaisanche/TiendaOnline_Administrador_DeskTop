using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Norah_API.Models.Entidad;
using System.Data.Entity.Infrastructure;

namespace AppAdminDesktop_Datos
{
    public class SubcategoriaDatos
    {
        public static SubCategoriaEntidad add(SubCategoriaEntidad obj)
        {
            SUBCATEGORIAS dato = new SUBCATEGORIAS();
            dato.ID_SUBCAT = obj.ID_SUBCAT;
            dato.ID_CATEGO_PER = obj.ID_CATEGO_PER;
            dato.NOM_SUBCATEGO = obj.NOM_SUBCATEGO;
            dato.DESC_SUBCATEGO = obj.DESC_SUBCATEGO;
            dato.IMAGEN = obj.IMAGEN;
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    dato = ctx.SUBCATEGORIAS.Add(dato);
                    obj.ID_SUBCAT = dato.ID_SUBCAT;
                    ctx.SaveChanges();
                }
                return obj;
            }
            catch (DbUpdateConcurrencyException)
            {
                return obj;
            }

        }
        public static bool edit(SubCategoriaEntidad obj)
        {
            SUBCATEGORIAS dato = new SUBCATEGORIAS();
            dato.ID_SUBCAT = obj.ID_SUBCAT;
            dato.ID_CATEGO_PER = obj.ID_CATEGO_PER;
            dato.NOM_SUBCATEGO = obj.NOM_SUBCATEGO;
            dato.DESC_SUBCATEGO = obj.DESC_SUBCATEGO;
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
        public static bool delete(SubCategoriaEntidad obj)
        {
            SUBCATEGORIAS dato = new SUBCATEGORIAS();
            dato.ID_SUBCAT = obj.ID_SUBCAT;
            dato.ID_CATEGO_PER = obj.ID_CATEGO_PER;
            dato.NOM_SUBCATEGO = obj.NOM_SUBCATEGO;
            dato.DESC_SUBCATEGO = obj.DESC_SUBCATEGO;
            dato.IMAGEN = obj.IMAGEN;
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    ctx.SUBCATEGORIAS.Remove(dato);
                    ctx.SaveChanges();
                    return true;
                }

            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

        }
        public static List<SubCategoriaEntidad> get()
        {
            List<SubCategoriaEntidad> lista = new List<SubCategoriaEntidad>();
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var ls = ctx.SUBCATEGORIAS.ToList();
                    foreach (var obj in ls)
                    {
                        SubCategoriaEntidad dato = new SubCategoriaEntidad();
                        dato.ID_SUBCAT = obj.ID_SUBCAT;
                        dato.ID_CATEGO_PER = obj.ID_CATEGO_PER;
                        dato.NOM_SUBCATEGO = obj.NOM_SUBCATEGO;
                        dato.DESC_SUBCATEGO = obj.DESC_SUBCATEGO;
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
        public static SubCategoriaEntidad get(int id)
        {
            SubCategoriaEntidad dato = new SubCategoriaEntidad();
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var obj = ctx.SUBCATEGORIAS.Where(x => x.ID_SUBCAT == id).FirstOrDefault();
                    dato.ID_SUBCAT = obj.ID_SUBCAT;
                    dato.ID_CATEGO_PER = obj.ID_CATEGO_PER;
                    dato.NOM_SUBCATEGO = obj.NOM_SUBCATEGO;
                    dato.DESC_SUBCATEGO = obj.DESC_SUBCATEGO;
                    dato.IMAGEN = obj.IMAGEN; ;

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
