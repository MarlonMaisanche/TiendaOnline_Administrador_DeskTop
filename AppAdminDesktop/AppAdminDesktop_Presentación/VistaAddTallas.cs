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
    public partial class VistaAddTallas : Form
    {
        ProductoEntidad producto;
        TallaProductoEntidad tallaProducto;
        VistaTallas vistaTallas;
        public VistaAddTallas()
        {
            InitializeComponent();
        }
        public VistaAddTallas(ProductoEntidad producto)
        {
            InitializeComponent();
            this.producto = producto;
            cargarDatos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            textBox_id.Text = "";
            textBox_id_talla.Text = "";
            textBox_precio.Text = "";
            textBox_precio_promo.Text = "";
            textBox_cantidad.Text = "";
            tallaProducto = null;
        }
        private bool verificar()
        {
            if (textBox_id_talla.Text == "")
            {
                return false;
            }
            if (textBox_precio.Text == "")
            {
                return false;
            }
            if (textBox_precio_promo.Text == "")
            {
                return false;
            }
            if (textBox_cantidad.Text == "")
            {
                return false;
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void guardar()
        {
            if (verificar())
            {
                tallaProducto = new TallaProductoEntidad();
                if (textBox_id.Text == "")
                {
                    tallaProducto.ID_TALL_PRO = 0;
                }
                else
                {
                    tallaProducto.ID_TALL_PRO = int.Parse(textBox_id.Text);
                }
                tallaProducto.ID_TALLA_PER = int.Parse(textBox_id_talla.Text);
                tallaProducto.ID_PRO_PER = producto.ID_PRO;
                tallaProducto.PRECIO_TALL = double.Parse(textBox_precio.Text);
                tallaProducto.PRECIO_TALL_PROM = double.Parse(textBox_precio_promo.Text);
                tallaProducto.CANTIDAD = int.Parse(textBox_cantidad.Text);
                if (tallaProducto.ID_TALL_PRO==0)
                {
                    TallaProductoNegocio.add(tallaProducto);
                }
                else
                {
                    TallaProductoNegocio.edit(tallaProducto);
                }
                cargarDatos();
                limpiar();
            }
            else
            {
                MessageBox.Show("Rellene los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cargarDatos()
        {
            dataGridView1.DataSource = TallaProductoNegocio.getByProductId(producto.ID_PRO);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cargarById(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID_TALL_PRO"].Value.ToString()));
        }

        private void cargarById(int v)
        {
            tallaProducto = TallaProductoNegocio.get(v);
            textBox_id.Text = tallaProducto.ID_TALL_PRO.ToString();
            textBox_id_talla.Text = tallaProducto.ID_TALLA_PER.ToString();
            textBox_precio.Text = tallaProducto.PRECIO_TALL.ToString();
            textBox_precio_promo.Text = tallaProducto.PRECIO_TALL_PROM.ToString();
            textBox_cantidad.Text = tallaProducto.CANTIDAD.ToString();
        }

        public void seleccionarTalla()
        {
            TallaEntidad talla = vistaTallas.talla;
            textBox_id_talla.Text = talla.ID_TALLA.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            eliminar();
        }

        private void eliminar()
        {
            if (tallaProducto!=null)
            {
                TallaProductoNegocio.delete(tallaProducto);
                limpiar();
                cargarDatos();
            }
            else
            {
                MessageBox.Show("Seleccione un elemento", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limpiar();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            seleccionarIDTalla();
        }

        private void seleccionarIDTalla()
        {
            vistaTallas = new VistaTallas(this);
            vistaTallas.Show();
        }
    }
}
