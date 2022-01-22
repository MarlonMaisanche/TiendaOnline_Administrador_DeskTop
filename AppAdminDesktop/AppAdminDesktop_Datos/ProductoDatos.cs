using Norah_API.Models.Entidad;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAdminDesktop_Datos
{
    public class ProductoDatos
    {
        public static ProductoEntidad guardar(ProductoEntidad producto)
        {
            Productos p = new Productos();
            p.ID_PRO = producto.ID_PRO;
            p.ID_TIPO = producto.ID_TIPO;
            p.NOM_PRO = producto.NOM_PRO;
            p.MARCA = producto.MARCA;
            p.ID_GENERO = producto.ID_GENERO;
            p.SUBTITULO_PRO = producto.SUBTITULO_PRO;
            p.PRECIO_PRO = producto.PRECIO_PRO;
            p.PRE_DESCU_PRO = producto.PRE_DESCU_PRO;
            p.COSTO_ENVIO = (double)producto.COSTO_ENVIO;
            p.DIAS_TARDA_LLEGAR = producto.DIAS_TARDA_LLEGAR;
            p.STOCK = producto.STOCK;
            p.DESCRIPCION_PRO = producto.DESCRIPCION_PRO;
            p.CALIFICACION_PRO = producto.CALIFICACION_PRO;
            p.ID_SUBCATEGORIA_PER = producto.ID_SUBCATEGORIA_PER;
            p.CANTIDAD_VENDIDA = (int)producto.CANTIDAD_VENDIDA;
            p.ESTADO = producto.ESTADO;
            p.PERSONALIZABLE = (int)producto.PERSONALIZABLE;
            p.DESCRIP_PERSONALIZABLE = producto.DESCRIP_PERSONALIZABLE;
            p.ID_SECCION = producto.ID_SECCION;
            using (NorahApiEntities ctx = new NorahApiEntities())
            {
                 p = ctx.Productos.Add(p);            
                ctx.SaveChanges();
            }
            producto.ID_PRO = p.ID_PRO;
            return producto;
        }

        public static List<ProductoEntidad> getByName(String name)
        {
            List<ProductoEntidad> lista = new List<ProductoEntidad>();
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    lista = (from producto in ctx.Productos
                             where producto.NOM_PRO.Contains(name)
                             select new ProductoEntidad
                             {
                                 ID_PRO = producto.ID_PRO,
                                 ID_TIPO = producto.ID_TIPO,
                                 NOM_PRO = producto.NOM_PRO,
                                 MARCA = producto.MARCA,
                                 ID_GENERO = producto.ID_GENERO,
                                 SUBTITULO_PRO = producto.SUBTITULO_PRO,
                                 PRECIO_PRO = producto.PRECIO_PRO,
                                 PRE_DESCU_PRO = producto.PRE_DESCU_PRO,
                                 COSTO_ENVIO = (double)producto.COSTO_ENVIO,
                                 DIAS_TARDA_LLEGAR = producto.DIAS_TARDA_LLEGAR,
                                 STOCK = producto.STOCK,
                                 DESCRIPCION_PRO = producto.DESCRIPCION_PRO,
                                 CALIFICACION_PRO = producto.CALIFICACION_PRO,
                                 ID_SUBCATEGORIA_PER = producto.ID_SUBCATEGORIA_PER,
                                 CANTIDAD_VENDIDA = (int)producto.CANTIDAD_VENDIDA,
                                 ESTADO = producto.ESTADO,
                                 PERSONALIZABLE = (int)producto.PERSONALIZABLE,
                                 DESCRIP_PERSONALIZABLE = producto.DESCRIP_PERSONALIZABLE,
                                 ID_SECCION = producto.ID_SECCION,
                             }).Distinct().Take(20).ToList();
            
                }
                return lista;
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }
        }
        public static List<ProductoEntidad> get()
        {
            List<ProductoEntidad> lista = new List<ProductoEntidad>();
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var ls = ctx.Productos.OrderByDescending(x=>x.ID_PRO).ToList().Take(20);
          
                    foreach (var producto in ls)
                    {
                        ProductoEntidad p = new ProductoEntidad();
                        p.ID_PRO = producto.ID_PRO;
                        p.ID_TIPO = producto.ID_TIPO;
                        p.NOM_PRO = producto.NOM_PRO;
                        p.MARCA = producto.MARCA;
                        p.ID_GENERO = producto.ID_GENERO;
                        p.SUBTITULO_PRO = producto.SUBTITULO_PRO;
                        p.PRECIO_PRO = producto.PRECIO_PRO;
                        p.PRE_DESCU_PRO = producto.PRE_DESCU_PRO;
                        p.COSTO_ENVIO = (double)producto.COSTO_ENVIO;
                        p.DIAS_TARDA_LLEGAR = producto.DIAS_TARDA_LLEGAR;
                        p.STOCK = producto.STOCK;
                        p.DESCRIPCION_PRO = producto.DESCRIPCION_PRO;
                        p.CALIFICACION_PRO = producto.CALIFICACION_PRO;
                        p.ID_SUBCATEGORIA_PER = producto.ID_SUBCATEGORIA_PER;
                        p.CANTIDAD_VENDIDA = (int)producto.CANTIDAD_VENDIDA;
                        p.ESTADO = producto.ESTADO;
                        p.PERSONALIZABLE = (int)producto.PERSONALIZABLE;
                        p.DESCRIP_PERSONALIZABLE = producto.DESCRIP_PERSONALIZABLE;
                        p.ID_SECCION = producto.ID_SECCION;
                        lista.Add(p);
                    }
                }
                return lista;
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }
        }

        public static ProductoEntidad get(int id)
        {
            ProductoEntidad p = new ProductoEntidad();
            try
            {
                using (NorahApiEntities ctx = new NorahApiEntities())
                {
                    var producto = ctx.Productos.Where(x => x.ID_PRO == id).FirstOrDefault();
                    p.ID_PRO = producto.ID_PRO;
                    p.ID_TIPO = producto.ID_TIPO;
                    p.NOM_PRO = producto.NOM_PRO;
                    p.MARCA = producto.MARCA;
                    p.ID_GENERO = producto.ID_GENERO;
                    p.SUBTITULO_PRO = producto.SUBTITULO_PRO;
                    p.PRECIO_PRO = producto.PRECIO_PRO;
                    p.PRE_DESCU_PRO = producto.PRE_DESCU_PRO;
                    p.COSTO_ENVIO = (double)producto.COSTO_ENVIO;
                    p.DIAS_TARDA_LLEGAR = producto.DIAS_TARDA_LLEGAR;
                    p.STOCK = producto.STOCK;
                    p.DESCRIPCION_PRO = producto.DESCRIPCION_PRO;
                    p.CALIFICACION_PRO = producto.CALIFICACION_PRO;
                    p.ID_SUBCATEGORIA_PER = producto.ID_SUBCATEGORIA_PER;
                    p.CANTIDAD_VENDIDA = (int)producto.CANTIDAD_VENDIDA;
                    p.ESTADO = producto.ESTADO;
                    p.PERSONALIZABLE = (int)producto.PERSONALIZABLE;
                    p.DESCRIP_PERSONALIZABLE = producto.DESCRIP_PERSONALIZABLE;
                    p.ID_SECCION = producto.ID_SECCION;

                }
                return p;
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }
        }
    }
}
