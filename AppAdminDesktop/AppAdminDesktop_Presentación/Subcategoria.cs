using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppAdminDesktop_Negocio;
using Norah_API.Models.Entidad;

namespace AppAdminDesktop_Presentación
{
    public partial class Subcategoria : Form
    {
        OpenFileDialog open;
        CrearProducto vistaAnterior;
        public SubCategoriaEntidad subcategoria= new SubCategoriaEntidad();
        Categoria vistaCategoria;
        public Subcategoria()
        {
            InitializeComponent();
            cargarDatos();
        }
        public Subcategoria(CrearProducto anterior)
        {
            InitializeComponent();
            vistaAnterior = anterior;
            
            cargarDatos();
        }

        private void cargarDatos()
        {
            
            dataGridView1.DataSource = SubcategoriaNegocio.get();
        }

        private void Subcategoria_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            cargarPorId(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID_SUBCAT"].Value.ToString()));
        }

        public  void seleccionarCategoria()
        {
            CategoriasEntidad categoria = vistaCategoria.categoria;
            textBox_id_categoria.Text = categoria.ID_CATEGORIA.ToString();
        }

        private void cargarPorId(int v)
        {
            subcategoria = SubcategoriaNegocio.get(v);
            textBox_id.Text = subcategoria.ID_SUBCAT.ToString();
            textBox_descripcion.Text =subcategoria.DESC_SUBCATEGO;
            textBox_id_categoria.Text = subcategoria.ID_CATEGO_PER.ToString();
            textBox_nombre.Text =subcategoria.NOM_SUBCATEGO;
            textBox_imagen.Text = subcategoria.IMAGEN;

        }
        public void limpiarCampos()
        {
            textBox_id.Text = "";
            textBox_descripcion.Text = "";
            textBox_id_categoria.Text = "";
            textBox_nombre.Text = "";
            textBox_imagen.Text = "";
            subcategoria = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
             open = new OpenFileDialog();
            open.Filter = "Imagenes (*.jpeg; *.jpg; *.gif; *.bmp;)|*.jpeg; *.jpg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                textBox_imagen.Text = open.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (subcategoria!=null)
            {
                vistaAnterior.seleccionarSubCategoria();
            }

            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            String ruta = "";
            ruta = "";
            ruta = open.FileName;
            string nombreImagen = ruta.Substring(ruta.LastIndexOf("\\") + 1);
            String url = PuntosConexion.URL_IMAGENES_SUBCATEGORIA;
           // String url = "http://localhost:16931/api/ResenaImage";
            String pathImage = open.FileName;
            var resp= API_MEDIA_STORE.Upload(url,pathImage);
            String name = resp.data;
            String message = resp.message;
            subcategoria.IMAGEN = name;
            MessageBox.Show(message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (verificar())
            {
                if (textBox_id.Text == "")
                {
                    subcategoria.ID_SUBCAT = 0;
                }
                else
                {
                    subcategoria.ID_SUBCAT = int.Parse(textBox_id.Text);
                }
                subcategoria.ID_CATEGO_PER = int.Parse(textBox_id_categoria.Text);
                subcategoria.NOM_SUBCATEGO = textBox_nombre.Text;
                subcategoria.DESC_SUBCATEGO = textBox_descripcion.Text;
                if (subcategoria.IMAGEN==null || subcategoria.IMAGEN == "")
                {
                    MessageBox.Show("Seleccione una imagen", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (textBox_id.Text == "")
                    {
                        guardar();
                    }
                    else
                    {
                        editar();
                    }
                    cargarDatos();
                }              
            }
            else
            {
                MessageBox.Show("Rellene los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
          
        }
        public bool verificar()
        {
           
            if (textBox_id_categoria.Text=="")
            {
                return false;
            }
            if (textBox_nombre.Text == "")
            {
                return false;
            }
            if (textBox_descripcion.Text == "")
            {
                return false;
            }
            if (textBox_imagen.Text == "")
            {
                return false;
            }
            return true;
        } 
        private void editar()
        {
            SubcategoriaNegocio.edit(subcategoria);
        }

        private void guardar()
        {
            SubcategoriaNegocio.add(subcategoria);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vistaCategoria = new Categoria(this);
            vistaCategoria.Show();
        }
    }
}
