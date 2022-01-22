using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Norah_API.Models.Entidad;
using AppAdminDesktop_Negocio;

namespace AppAdminDesktop_Presentación
{
    public partial class VistaAddColores : Form
    {
        ProductoEntidad producto;
        ColorProductoEntidad colorProducto;
        OpenFileDialog open;
        VistaColor vistaColor;
        public VistaAddColores()
        {
            InitializeComponent();
        }
        public VistaAddColores(ProductoEntidad producto)
        {
            InitializeComponent();
            this.producto = producto;
            cargarDatos();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            colorProducto = null;
            textBox_id.Text = "";
            textBox_id_color.Text = "";
            textBox_imagen.Text = "";
            textBox_cantidad.Text = "";
        }
        private bool verificar()
        {
            if (textBox_id_color.Text=="")
            {
                return false;
            }

            if (textBox_imagen.Text == "")
            {
                return false;
            }

            if (textBox_cantidad.Text == "")
            {
                return false;
            }
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            seleccionarImagen();
        }

        private void seleccionarImagen()
        {
            open = new OpenFileDialog();
            open.Filter = "Imagenes (*.jpeg; *.jpg; *.gif; *.bmp;)|*.jpeg; *.jpg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                textBox_imagen.Text = open.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (verificar())
            {
                colorProducto = new ColorProductoEntidad();
                //Controlar que la imagen a sido actualizada 
                colorProducto.IMAGEN = textBox_imagen.Text;
                if (textBox_imagen.Text.IndexOf("imagenes_productos") == -1)
                {
                    guardarImagen();
                }
                
                if (colorProducto.IMAGEN != "")
                {
                    if (textBox_id.Text == "")
                    {
                        colorProducto.ID_COL_PRO = 0;
                    }
                    else
                    {
                        colorProducto.ID_COL_PRO = int.Parse(textBox_id.Text);
                    }
                    colorProducto.ID_COLOR =int.Parse( textBox_id_color.Text);
                    colorProducto.ID_PRO_PER = producto.ID_PRO;
                    colorProducto.CANTIDAD =int.Parse( textBox_cantidad.Text);
                    if (colorProducto.ID_COL_PRO == 0)
                    {
                        ColorProductoNegocio.add(colorProducto);
                    }
                    else
                    {
                        ColorProductoEntidad imgAnterior = ColorProductoNegocio.get(colorProducto.ID_COL_PRO);
                        var res = ColorProductoNegocio.edit(colorProducto);
                        if (res)
                        {
                            actualizarImagenServidor(colorProducto, imgAnterior);
                        }

                    }
                    cargarDatos();
                    limpiar();
                }
                else
                {
                    MessageBox.Show("Guarde la imagen", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Rellene los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        internal void seleccionarColor()
        {
            ColorEntidad color =vistaColor.color;
            textBox_id_color.Text = color.ID_COLOR.ToString();
        }

        private void cargarDatos()
        {
            dataGridView1.DataSource = ColorProductoNegocio.getByProductID(producto.ID_PRO);
        }

        private void actualizarImagenServidor(ColorProductoEntidad colorProducto, ColorProductoEntidad imgAnterior)
        {
            if (colorProducto.IMAGEN != imgAnterior.IMAGEN)
            {
                eliminarImagenServidor(imgAnterior);
            }
        }
        private void eliminarImagenServidor(ColorProductoEntidad imagen)
        {
            String nombre = imagen.IMAGEN.Replace("imagenes_productos/", "");
            String url = PuntosConexion.URL_DELETE_IMAGENES_PRODUCTOS + nombre;
            var resp = API_MEDIA_STORE.Delete(url);
        }
        private void guardarImagen()
        {
            String url = PuntosConexion.URL_IMAGENES_PRODUCTOS;
            String pathImage = open.FileName;
            var resp = API_MEDIA_STORE.Upload(url, pathImage);
            String name = resp.data;
            String message = resp.message;
            colorProducto.IMAGEN = name;
            MessageBox.Show(message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            eliminar();
        }

        private void eliminar()
        {
            if (colorProducto != null)
            {
                ColorProductoNegocio.delete(colorProducto);
                eliminarImagenServidor(colorProducto);
                limpiar();
                cargarDatos();
            }
            else
            {
                MessageBox.Show("Seleccione un elemento", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cargarPorId(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID_COL_PRO"].Value.ToString()));

        }

        private void cargarPorId(int id)
        {
            colorProducto = ColorProductoNegocio.get(id);
            textBox_id.Text = colorProducto.ID_COL_PRO.ToString();
            textBox_id_color.Text = colorProducto.ID_COLOR.ToString();
            textBox_imagen.Text = colorProducto.IMAGEN;
            textBox_cantidad.Text = colorProducto.CANTIDAD.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            opeenViewColor();
        }

        private void opeenViewColor()
        {
            vistaColor = new VistaColor(this);
            vistaColor.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
