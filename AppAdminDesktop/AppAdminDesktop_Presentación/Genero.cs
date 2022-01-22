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
using Norah_API.Models.Entidad;

namespace AppAdminDesktop_Presentación
{
    public partial class Genero : Form
    {
        public GeneroEntidad genero;
        CrearProducto ventanaAnterior;
        public Genero()
        {
            InitializeComponent();
        }
        public Genero(CrearProducto anterior)
        {
            InitializeComponent();
            ventanaAnterior = anterior;
            cargarDatos();
        }

        private void cargarDatos()
        {
            dataGridView1.DataSource = GeneroNegocio.get();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cargarPorId(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID_GENERO"].Value.ToString()));
        }

        private void cargarPorId(int v)
        {
            genero = GeneroNegocio.get(v);
            textBox1.Text = genero.GENERO1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (genero!=null)
            {
                ventanaAnterior.seleccinarGenero();
            }

            this.Close(); 
        }
    }
}
