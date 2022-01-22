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
using AppAdminDesktop_Negocio;

namespace AppAdminDesktop_Presentación
{
    public partial class Seccion : Form
    {
        CrearProducto vistaAnterior;
       public  SeccionEntidad seccion;
        public Seccion()
        {
            InitializeComponent();
        }
        public Seccion(CrearProducto anterior)
        {
            InitializeComponent();
            vistaAnterior = anterior;
            cargarDatos();
        }

        private void cargarDatos()
        {
            dataGridView1.DataSource = SeccionNegocio.get();
        }

        private void Seccion_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cargarPorId(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID_SECCION"].Value.ToString()));
        }

        private void cargarPorId(int v)
        {
            seccion = SeccionNegocio.get(v);
            textBox_id.Text = (seccion.ID_SECCION.ToString());
            textBox_nombre.Text = seccion.NOMBRE_SECCION;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            guardarSeccion();
        }

        private void guardarSeccion()
        {
            if (textBox_id.Text=="")
            {
                guardar();
            }
            else
            {
                editar();
            }
            cargarDatos();
        }

        private void guardar()
        {
            seccion.ID_SECCION = 0;
            seccion.NOMBRE_SECCION = textBox_nombre.Text;
            SeccionNegocio.add(seccion);
        }

        private void editar()
        {
            seccion.ID_SECCION = int.Parse(textBox_id.Text);
            seccion.NOMBRE_SECCION = textBox_nombre.Text;
            SeccionNegocio.edit(seccion);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (seccion != null)
            {
                vistaAnterior.seleccionarSeccion();
            }
           
            this.Close();
        }
    }
}
