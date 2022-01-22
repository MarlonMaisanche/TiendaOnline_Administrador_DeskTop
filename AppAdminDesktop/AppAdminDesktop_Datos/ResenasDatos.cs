using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Norah_API.Models.Entidad;
using System.Data.Entity.Infrastructure;

namespace AppAdminDesktop_Datos
{
   public  class ResenasDatos
    {
        public static ResenaEntidad add(ResenaEntidad obj)
        {
            RESENAS dato = new RESENAS();
            dato.ID_RESE = obj.ID_RESE;
            dato.ID_PROD_PER = obj.ID_PROD_PER;
            dato.ID_USU_ESCR = obj.ID_USU_ESCR;
            dato.TITULO = obj.TITULO;
            dato.VALORACION = obj.VALORACION;
            dato.COMENTARIO = obj.COMENTARIO;
            dato.ESTADO = obj.ESTADO;
            dato.FECHA = obj.FECHA;
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    dato = ctx.RESENAS.Add(dato);
                    obj.ID_RESE = dato.ID_RESE;
                    ctx.SaveChanges();
                }
                return obj;
            }
            catch (DbUpdateConcurrencyException)
            {
                return obj;
            }

        }

        public static List<ResenaEntidad> getByProductID(int id)
        {
            List<ResenaEntidad> lista = new List<ResenaEntidad>();
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var ls = ctx.RESENAS.Where(x=>x.ID_PROD_PER==id);
                    foreach (var obj in ls)
                    {
                        ResenaEntidad dato = new ResenaEntidad();
                        dato.ID_RESE = obj.ID_RESE;
                        dato.ID_PROD_PER = obj.ID_PROD_PER;
                        dato.ID_USU_ESCR = obj.ID_USU_ESCR;
                        dato.TITULO = obj.TITULO;
                        dato.VALORACION = obj.VALORACION;
                        dato.COMENTARIO = obj.COMENTARIO;
                        dato.ESTADO = obj.ESTADO;
                        dato.FECHA = obj.FECHA;
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

        public static bool edit(ResenaEntidad obj)
        {
            RESENAS dato = new RESENAS();
            dato.ID_RESE = obj.ID_RESE;
            dato.ID_PROD_PER = obj.ID_PROD_PER;
            dato.ID_USU_ESCR = obj.ID_USU_ESCR;
            dato.TITULO = obj.TITULO;
            dato.VALORACION = obj.VALORACION;
            dato.COMENTARIO = obj.COMENTARIO;
            dato.ESTADO = obj.ESTADO;
            dato.FECHA = obj.FECHA;
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
        public static bool delete(ResenaEntidad obj)
        {
        
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var item = ctx.RESENAS.Find(obj.ID_RESE);
                    ctx.RESENAS.Remove(item);
                    ctx.SaveChanges();
                    return true;
                }

            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

        }
        public static List<ResenaEntidad> get()
        {
            List<ResenaEntidad> lista = new List<ResenaEntidad>();
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var ls = ctx.RESENAS.ToList();
                    foreach (var obj in ls)
                    {
                        ResenaEntidad dato = new ResenaEntidad();
                        dato.ID_RESE = obj.ID_RESE;
                        dato.ID_PROD_PER = obj.ID_PROD_PER;
                        dato.ID_USU_ESCR = obj.ID_USU_ESCR;
                        dato.TITULO = obj.TITULO;
                        dato.VALORACION = obj.VALORACION;
                        dato.COMENTARIO = obj.COMENTARIO;
                        dato.ESTADO = obj.ESTADO;
                        dato.FECHA = obj.FECHA;
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
        public static ResenaEntidad get(int id)
        {
            ResenaEntidad dato = new ResenaEntidad();
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var obj = ctx.RESENAS.Where(x => x.ID_RESE == id).FirstOrDefault();
                    dato.ID_RESE = obj.ID_RESE;
                    dato.ID_PROD_PER = obj.ID_PROD_PER;
                    dato.ID_USU_ESCR = obj.ID_USU_ESCR;
                    dato.TITULO = obj.TITULO;
                    dato.VALORACION = obj.VALORACION;
                    dato.COMENTARIO = obj.COMENTARIO;
                    dato.ESTADO = obj.ESTADO;
                    dato.FECHA = obj.FECHA;

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
