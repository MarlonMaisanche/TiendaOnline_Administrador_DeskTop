using Norah_API.Models.Entidad;
using AppAdminDesktop_Negocio;
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
    public partial class Categoria : Form
    {
        OpenFileDialog open;
        public CategoriasEntidad categoria;
        Subcategoria ventanaAnterior;
        public Categoria()
        {
            InitializeComponent();
        }
        public Categoria(Subcategoria anterior)
        {
            InitializeComponent();
            ventanaAnterior = anterior;
            categoria = new CategoriasEntidad();
            cargarDatos();
            //this.Closing += new CancelEventHandler(Form2_Closing);
        }

        private void cargarDatos()
        {
            dataGridView1.DataSource=CategoriaNegocio.get();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            seleccionar();
        }

        private void seleccionar()
        {
            ventanaAnterior.seleccionarCategoria();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
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
            String url = PuntosConexion.URL_IMAGENES_CATEGORIA;
            String pathImage = open.FileName;
            var resp = API_MEDIA_STORE.Upload(url, pathImage);
            String name = resp.data;
            String message = resp.message;
            categoria.IMAGEN = name;
            MessageBox.Show(message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cargarPorId(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID_CATEGORIA"].Value.ToString()));
        }

        private void cargarPorId(int v)
        {
            categoria = CategoriaNegocio.get(v);
            textBox_id.Text = categoria.ID_CATEGORIA.ToString();
            textBox_nombre.Text = categoria.NOM_CATEGORIA;
            textBox_imagen.Text = categoria.IMAGEN;
        }
        private void limpiar()
        {
            textBox_id.Text = "";
            textBox_nombre.Text = "";
            textBox_imagen.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            guardarCategoria();
        }

        private void guardarCategoria()
        {
            if(verificar()){
                if (textBox_id.Text == "")
                {
                    categoria.ID_CATEGORIA = 0;
                }
                else
                {
                    categoria.ID_CATEGORIA = int.Parse(textBox_id.Text);
                }
                categoria.NOM_CATEGORIA = textBox_nombre.Text;
                if (categoria.IMAGEN==null || categoria.IMAGEN == "")
                {
                    MessageBox.Show("Seleccione una imagen", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (textBox_id.Text == "")
                    {
                        CategoriaNegocio.add(categoria);
                    }
                    else
                    {
                        CategoriaNegocio.edit(categoria);
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
            if (textBox_nombre.Text == "")
            {
                return false;
            }
            if (textBox_imagen.Text == "")
            {
                return false;
            }        
            return true;
        }

        void Form2_Closing(object sender, CancelEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
