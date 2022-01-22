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
    public partial class TipoProducto : Form
    {
        public TipoProductoEntidad seleccion;
        CrearProducto vistaAnterior;
        public TipoProducto()
        {
            InitializeComponent();
            cargarDatos();
        }
        public TipoProducto(CrearProducto anterior)
        {
            InitializeComponent();
            vistaAnterior = anterior;
            cargarDatos();
        }

        private void cargarDatos()
        {
            dataGridView1.DataSource = TipoProductoNegocio.get();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            buscar();
        }

        private void buscar()
        {
            String nombre = textBox_nombre.Text;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            guardarSeleccion();
            
        }

        private void guardarSeleccion()
        {
            if (seleccion!=null)
            {
               vistaAnterior.seleccionarTipo();
            }
            
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cargarById(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID_TIPO_PRODUCTO"].Value.ToString()));
        }

        private void cargarById(int v)
        {
            seleccion = TipoProductoNegocio.get(v);
            textBox_seleccion.Text = seleccion.NOMBRE_TIPO;
        }
    }
}
