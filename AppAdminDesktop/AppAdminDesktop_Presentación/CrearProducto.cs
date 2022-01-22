using AppAdminDesktop_Negocio;
using Norah_API.Models.Entidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppAdminDesktop_Presentación
{
    public partial class CrearProducto : Form
    {
        
        ProductoEntidad producto = new ProductoEntidad();
        TipoProducto vistaTipoProducto;
        Genero vistaGenero;
        Seccion vistaSeccion;
        Subcategoria vistaSubcategoria;
        public CrearProducto()
        {
            InitializeComponent();
            bloquearBotones();    
        }


        public CrearProducto(ProductoEntidad producto )
        {
            InitializeComponent();
            this.producto = producto;
            cargarDatos();
        }

        private void cargarDatos()
        {
            textBox_id.Text = producto.ID_PRO.ToString();
            textBox_id_tipo_producto.Text = producto.ID_TIPO.ToString();
            textBox_marca.Text = producto.MARCA.ToString();
            textBox_nombre.Text = producto.NOM_PRO.ToString();
            textBox_subtitulo.Text = producto.SUBTITULO_PRO.ToString();
            textBox_id_genero.Text = producto.ID_GENERO.ToString();
            textBox_precio.Text = producto.PRECIO_PRO.ToString();
            textBox_precio_descuento.Text = producto.PRE_DESCU_PRO.ToString();
            textBox_costo_envio.Text = producto.COSTO_ENVIO.ToString();
            textBox_dias_tarda.Text = producto.DIAS_TARDA_LLEGAR.ToString();
            textBox_stock.Text = producto.STOCK.ToString();
            textBox_descripcion.Text = producto.DESCRIPCION_PRO.ToString();
            textBox_calificacion.Text = producto.CALIFICACION_PRO.ToString();
            textBox_id_subcategoria.Text = producto.ID_SUBCATEGORIA_PER.ToString();
            textBox_cantidad_vendida.Text = producto.CANTIDAD_VENDIDA.ToString();
            textBox_descripcion_per.Text = producto.DESCRIP_PERSONALIZABLE.ToString();
            textBox_id_seccion.Text = producto.ID_SECCION.ToString();
            if (producto.PERSONALIZABLE==1)
            {
                checkBox_perzonalizable.Checked = true;
            }
            


        }

        private void bloquearBotones()
        {
            button_img.Enabled = false;
            button_tall.Enabled = false;
            button_col.Enabled = false;
            button_deta.Enabled = false;
            button_rese.Enabled = false;
            button_tag.Enabled = false;

        }

        public  void seleccinarGenero()
        {
           GeneroEntidad genero= vistaGenero.genero;
           textBox_id_genero.Text = genero.ID_GENERO.ToString();
        }

        private void desbloquearBotonse()
        {
            button_img.Enabled = true;
            button_tall.Enabled = true;
            button_col.Enabled = true;
            button_deta.Enabled = true;
            button_rese.Enabled = true;
            button_tag.Enabled = true;

        }

        public void  seleccionarSubCategoria()
        {
            SubCategoriaEntidad subcategoria = vistaSubcategoria.subcategoria;
            textBox_id_subcategoria.Text = subcategoria.ID_SUBCAT.ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            GuardarProducto();
        }

        private void GuardarProducto()
        {
            if (textBox_id.Text=="")
            {
                producto.ID_PRO = 0;
            }
            else
            {
             producto.ID_PRO = int.Parse(textBox_id.Text);
            }
            producto.ID_TIPO =int.Parse( textBox_id_tipo_producto.Text);
            producto.MARCA = textBox_marca.Text;
            producto.NOM_PRO = textBox_nombre.Text;
            producto.SUBTITULO_PRO = textBox_subtitulo.Text;
            producto.ID_GENERO = int.Parse(textBox_id_genero.Text);
            producto.PRECIO_PRO = double.Parse(textBox_precio.Text);
            producto.PRE_DESCU_PRO = double.Parse(textBox_precio_descuento.Text);
            producto.COSTO_ENVIO = double.Parse(textBox_costo_envio.Text);
            producto.DIAS_TARDA_LLEGAR = int.Parse(textBox_dias_tarda.Text);
            producto.STOCK = int.Parse(textBox_stock.Text);
            producto.DESCRIPCION_PRO = textBox_descripcion.Text;
            producto.CALIFICACION_PRO = double.Parse(textBox_calificacion.Text);
            producto.ID_SUBCATEGORIA_PER = int.Parse(textBox_id_subcategoria.Text);
            producto.CALIFICACION_PRO = int.Parse(textBox_calificacion.Text);
            producto.ESTADO = 1;
            if (checkBox_perzonalizable.Checked)
            {
                producto.PERSONALIZABLE = 1;
            }
            else
            {
                producto.PERSONALIZABLE = 0;
            }
            producto.DESCRIP_PERSONALIZABLE = textBox_descripcion_per.Text;
            producto.ID_SECCION = int.Parse(textBox_id_seccion.Text);
            this.producto=ProductoNegocio.guardar(producto);
            textBox_id.Text = producto.ID_PRO.ToString();
            if (this.producto.ID_PRO!=0)
            {
                desbloquearBotonse();
            }

        }

        public void seleccionarSeccion()
        {
            SeccionEntidad seccion = vistaSeccion.seccion;
            textBox_id_seccion.Text = seccion.ID_SECCION.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vistaTipoProducto = new TipoProducto(this);
            vistaTipoProducto.Show();
        }
        public void  seleccionarTipo()
        {
            TipoProductoEntidad tipo = vistaTipoProducto.seleccion;
            textBox_id_tipo_producto.Text = tipo.ID_TIPO_PRODUCTO.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            vistaGenero = new Genero(this);
            vistaGenero.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            vistaSubcategoria = new Subcategoria(this);
            vistaSubcategoria.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            vistaSeccion = new Seccion(this);
           
            vistaSeccion.Show();
        }

        private void button_img_Click(object sender, EventArgs e)
        {
            annadirImagenesProducto();
        }

        private void annadirImagenesProducto()
        {
            VistaAddImagenes vistaImagenes = new VistaAddImagenes(producto);
            vistaImagenes.Show();
        }

        private void button_tall_Click(object sender, EventArgs e)
        {
            annadirTallas();
        }

        private void annadirTallas()
        {
            VistaAddTallas vistaTallas = new VistaAddTallas(producto);
            vistaTallas.Show();
        }

        private void button_col_Click(object sender, EventArgs e)
        {
            annadirColores();
        }

        private void annadirColores()
        {
            VistaAddColores vista =new  VistaAddColores(producto);
            vista.Show();
        }

        private void button_deta_Click(object sender, EventArgs e)
        {
            annadirDetalles();
        }

        private void annadirDetalles()
        {
            VistaAddDetalles vistaDetalles = new VistaAddDetalles(producto);
            vistaDetalles.Show();
        }

        private void button_rese_Click(object sender, EventArgs e)
        {
            annadirResenas();
        }

        private void annadirResenas()
        {
            VistaAddResenas vistaResenas = new VistaAddResenas(producto);
            vistaResenas.Show();
        }

        private void button_tag_Click(object sender, EventArgs e)
        {
            annadirTagBusqueda();
        }

        private void annadirTagBusqueda()
        {
            VistaAddTag vistaTag = new VistaAddTag(producto);
            vistaTag.Show();
        }
    }
}
