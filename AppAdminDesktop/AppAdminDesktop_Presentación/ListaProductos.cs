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
    public partial class ListaProductos : Form
    {
        ProductoEntidad producto;
        public ListaProductos()
        {
            InitializeComponent();
            cargarDatos();
        }

        private void cargarDatos()
        {
            dataGridView1.DataSource = ProductoNegocio.get();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cargarById(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID_PRO"].Value.ToString()));
        }

        private void cargarById(int v)
        {
            producto = ProductoNegocio.get(v);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (producto!= null)
            {
                CrearProducto vistaProducto = new CrearProducto(producto);
                vistaProducto.Show();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buscar();
        }

        private void buscar()
        {
            if (textBox_nombre.Text!="")
            {
                String busqueda = textBox_nombre.Text;
                dataGridView1.DataSource = ProductoNegocio.getByName(busqueda);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cargarDatos();
        }
    }
}
