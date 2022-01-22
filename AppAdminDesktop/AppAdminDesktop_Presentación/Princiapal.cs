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
    public partial class Princiapal : Form
    {
        public Princiapal()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CrearProducto vista = new CrearProducto();
            vista.Show();
        }

        private void lista_productos_Click(object sender, EventArgs e)
        {
            ListaProductos vistaLista = new ListaProductos();
            vistaLista.Show();
        }

        private void usuarios_Click(object sender, EventArgs e)
        {
            VistaUsuarios vistaUsuarios = new VistaUsuarios();
            vistaUsuarios.Show();
        }
    }
}
