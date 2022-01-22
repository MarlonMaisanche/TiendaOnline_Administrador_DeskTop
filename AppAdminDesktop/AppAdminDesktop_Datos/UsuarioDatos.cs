using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Norah_API.Models.Entidad;
using System.Data.Entity.Infrastructure;

namespace AppAdminDesktop_Datos
{
    public class UsuarioDatos
    {
        public static UsuarioEntidad add(UsuarioEntidad obj)
        {
            USUARIOS dato = new USUARIOS();
            dato.ID_USUARIO = obj.ID_USUARIO;
            dato.CORREO = obj.CORREO;
            dato.PASS = obj.PASS;
            dato.NOMBRE = obj.NOMBRE;
            dato.APELLIDO = obj.CORREO;
            dato.CEDULA = obj.CEDULA;
            dato.ID_GENERO = obj.ID_GENERO;
            dato.TELEFONO = obj.TELEFONO;
            dato.ID_DIR_PRI = obj.ID_DIR_PRI;
            dato.VAL_USU = obj.VAL_USU;
            dato.FEC_CREA = obj.FEC_CREA;
            dato.ESTADO = obj.ESTADO;

            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    dato = ctx.USUARIOS.Add(dato);
                    obj.ID_USUARIO = dato.ID_USUARIO;
                    ctx.SaveChanges();
                }
                return obj;
            }
            catch (DbUpdateConcurrencyException)
            {
                return obj;
            }

        }
        public static bool edit(UsuarioEntidad obj)
        {
            USUARIOS dato = new USUARIOS();
            dato.ID_USUARIO = obj.ID_USUARIO;
            dato.CORREO = obj.CORREO;
            dato.PASS = obj.PASS;
            dato.NOMBRE = obj.NOMBRE;
            dato.APELLIDO = obj.CORREO;
            dato.CEDULA = obj.CEDULA;
            dato.ID_GENERO = obj.ID_GENERO;
            dato.TELEFONO = obj.TELEFONO;
            dato.ID_DIR_PRI = obj.ID_DIR_PRI;
            dato.VAL_USU = obj.VAL_USU;
            dato.FEC_CREA = obj.FEC_CREA;
            dato.ESTADO = obj.ESTADO;
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
        public static bool delete(UsuarioEntidad obj)
        {

            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var item = ctx.USUARIOS.Find(obj.ID_USUARIO);
                    ctx.USUARIOS.Remove(item);
                    ctx.SaveChanges();
                    return true;
                }

            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

        }
        public static List<UsuarioEntidad> get()
        {
            List<UsuarioEntidad> lista = new List<UsuarioEntidad>();
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var ls = ctx.USUARIOS.ToList();
                    foreach (var obj in ls)
                    {
                        UsuarioEntidad dato = new UsuarioEntidad();
                        dato.ID_USUARIO = obj.ID_USUARIO;
                        dato.CORREO = obj.CORREO;
                        dato.PASS = obj.PASS;
                        dato.NOMBRE = obj.NOMBRE;
                        dato.APELLIDO = obj.CORREO;
                        dato.CEDULA = obj.CEDULA;
                        dato.ID_GENERO = obj.ID_GENERO;
                        dato.TELEFONO = obj.TELEFONO;
                        dato.ID_DIR_PRI = obj.ID_DIR_PRI;
                        dato.VAL_USU = obj.VAL_USU;
                        dato.FEC_CREA = obj.FEC_CREA;
                        dato.ESTADO = obj.ESTADO;
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
        public static UsuarioEntidad get(int id)
        {
            UsuarioEntidad dato = new UsuarioEntidad();
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var obj = ctx.USUARIOS.Where(x => x.ID_USUARIO == id).FirstOrDefault();
                    dato.ID_USUARIO = obj.ID_USUARIO;
                    dato.CORREO = obj.CORREO;
                    dato.PASS = obj.PASS;
                    dato.NOMBRE = obj.NOMBRE;
                    dato.APELLIDO = obj.CORREO;
                    dato.CEDULA = obj.CEDULA;
                    dato.ID_GENERO = obj.ID_GENERO;
                    dato.TELEFONO = obj.TELEFONO;
                    dato.ID_DIR_PRI = obj.ID_DIR_PRI;
                    dato.VAL_USU = obj.VAL_USU;
                    dato.FEC_CREA = obj.FEC_CREA;
                    dato.ESTADO = obj.ESTADO;

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
