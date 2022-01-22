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
    public partial class VistaAddImagenes : Form
    {
        OpenFileDialog open;
        ProductoEntidad producto;
        ImagenProductoEntidad imagen;
        ImagenResenaEntidad imagenResena;
        ResenaEntidad resena;
        public VistaAddImagenes()
        {
            InitializeComponent();
        }
        public VistaAddImagenes(ProductoEntidad producto)
        {
            InitializeComponent();
            this.producto = producto;
            cargarDatos();
        }
        public VistaAddImagenes(ResenaEntidad resena)
        {
            InitializeComponent();
            this.resena = resena;
            cargarDatosResena();
        }
        // Imagen Resena
        private void cargarDatosResena()
        {
            dataGridView1.DataSource = ImagenResenaNegocio.getByResenatID(resena.ID_RESE);
        }
        //Imagen Producto
        private void cargarDatos()
        {
            dataGridView1.DataSource = ImageneProductoNegocio.getByProductId(producto.ID_PRO);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            textBox_id.Text = "";
            textBox_imagen.Text = "";
            imagen = null;
            imagenResena = null;
        }

        private void examinar_Click(object sender, EventArgs e)
        {
            open = new OpenFileDialog();
            open.Filter = "Imagenes (*.jpeg; *.jpg; *.gif; *.bmp;)|*.jpeg; *.jpg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                textBox_imagen.Text = open.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void guardar()
        {
            
            if (verificar())
            {
                if(resena == null)
               {
                    guardarImagenProducto();
                }
                else
                {
                    guardarImagenResena();
                }
               
            }
            else
            {
                MessageBox.Show("Rellene los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void guardarImagenResena()
        {
            imagenResena = new ImagenResenaEntidad();
            guardarImagenResenaServidor();
            if (imagenResena.IMAGE != null)
            {
                if (textBox_id.Text == "")
                {
                    imagenResena.ID_IMA_RES = 0;
                }
                else
                {
                    imagenResena.ID_IMA_RES = int.Parse(textBox_id.Text);
                }

                imagenResena.ID_RES_PER = resena.ID_RESE;
                if (imagenResena.ID_IMA_RES == 0)
                {
                    ImagenResenaNegocio.add(imagenResena);
                }
                else
                {
                    ImagenResenaEntidad imgAnterior = ImagenResenaNegocio.get(imagenResena.ID_IMA_RES);
                    var res = ImagenResenaNegocio.edit(imagenResena);
                    if (res)
                    {
                        actualizarImagenResenaServidor(imagenResena, imgAnterior);
                    }

                }
                cargarDatosResena();
                limpiar();
            }
            else
            {
                MessageBox.Show("Guarde la imagen", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void actualizarImagenResenaServidor(ImagenResenaEntidad imagenResena, ImagenResenaEntidad imgAnterior)
        {
            if (imagenResena.IMAGE != imgAnterior.IMAGE)
            {
                eliminarImagenServidor(imgAnterior.IMAGE);
            }
        }

        private void guardarImagenResenaServidor()
        {
            String url = PuntosConexion.URL_DELETE_IMAGENES_RESE;
            String pathImage = open.FileName;
            var resp = API_MEDIA_STORE.Upload(url, pathImage);
            String name = resp.data;
            String message = resp.message;
            imagenResena.IMAGE = name;
            MessageBox.Show(message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void guardarImagenProducto()
        {
            imagen = new ImagenProductoEntidad();
            guardarImagen();
            if (imagen.IMAGEN != null)
            {
                if (textBox_id.Text == "")
                {
                    imagen.ID_IMAGEN = 0;
                }
                else
                {
                    imagen.ID_IMAGEN = int.Parse(textBox_id.Text);
                }

                imagen.ID_PROD_PER = producto.ID_PRO;
                if (imagen.ID_IMAGEN == 0)
                {
                    ImageneProductoNegocio.add(imagen);
                }
                else
                {
                    ImagenProductoEntidad imgAnterior = ImageneProductoNegocio.get(imagen.ID_IMAGEN);
                    var res = ImageneProductoNegocio.edit(imagen);
                    if (res)
                    {
                        actualizarImagenServidor(imagen, imgAnterior);
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

        private void actualizarImagenServidor(ImagenProductoEntidad imagen, ImagenProductoEntidad imgAnterior)
        {      
            if (imagen.IMAGEN != imgAnterior.IMAGEN)
            {
                eliminarImagenServidor(imgAnterior.IMAGEN);
            }
        }

        private bool verificar()
        {
            if (textBox_imagen.Text=="")
            {
                return false;
            }
            return true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void guardarImagen()
        {
            String url = PuntosConexion.URL_IMAGENES_PRODUCTOS;
            String pathImage = open.FileName;
            var resp = API_MEDIA_STORE.Upload(url, pathImage);
            String name = resp.data;
            String message = resp.message;
            imagen.IMAGEN = name;
            MessageBox.Show(message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            eliminarProductoImagen();
        }

        private void eliminarProductoImagen()
        {
            if (resena == null)
            {
                if (imagen != null)
                {
                    ImageneProductoNegocio.delete(imagen);
                    eliminarImagenServidor(imagen.IMAGEN);
                    limpiar();
                    cargarDatos();
                }
                else
                {
                    MessageBox.Show("Seleccione un elemento", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (imagenResena != null)
                {
                    ImagenResenaNegocio.delete(imagenResena);
                    eliminarImagenServidor(imagenResena.IMAGE);
                    limpiar();
                    cargarDatosResena();
                }
                else
                {
                    MessageBox.Show("Seleccione un elemento", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }

        private void eliminarImagenServidor(String imagen)
        {
            if (resena==null)
            {
                String nombre = imagen.Replace("imagenes_productos/", "");
                String url = PuntosConexion.URL_DELETE_IMAGENES_PRODUCTOS + nombre;
                var resp = API_MEDIA_STORE.Delete(url);
            }
            else
            {
                String nombre = imagen.Replace("resenas_productos/", "");
                String url = PuntosConexion.URL_DELETE_IMAGENES_RESE + nombre;
                var resp = API_MEDIA_STORE.Delete(url);
            }
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
         
            if (resena==null)
            {
                cargarPorId(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID_IMAGEN"].Value.ToString()));
            }
            else
            {
               cargarPorIdResena(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID_IMA_RES"].Value.ToString()));
            }
           
        }

        private void cargarPorIdResena(int v)
        {
            imagenResena = ImagenResenaNegocio.get(v);
            textBox_id.Text = imagenResena.ID_IMA_RES.ToString();
            textBox_imagen.Text = imagenResena.IMAGE;
        }

        private void cargarPorId(int v)
        {
            imagen = ImageneProductoNegocio.get(v);
            textBox_id.Text = imagen.ID_IMAGEN.ToString();
            textBox_imagen.Text = imagen.IMAGEN;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limpiar();
            this.Close();
        }
    }
}
