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
    public partial class VistaAddDetalles : Form
    {
        DetalleProductoEntidad detalle;
        ProductoEntidad producto;
        public VistaAddDetalles()
        {
            InitializeComponent();
        }
        public VistaAddDetalles(ProductoEntidad producto)
        {
            InitializeComponent();
            this.producto = producto;
            cargarDatos();
        }

        private void cargarDatos()
        {
            dataGridView1.DataSource = DetalleProductoNegocio.getByProductId(producto.ID_PRO);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void limpiarCampos()
        {
            textBox_id.Text = "";
            textBox_titulo.Text = "";
            textBox_contenido.Text = "";
            detalle = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void guardar()
        {
            if (verificar())
            {
                 detalle = new DetalleProductoEntidad();
                if (textBox_id.Text=="")
                {
                    detalle.ID_DETALLE = 0;
                }
                else
                {
                    detalle.ID_DETALLE = int.Parse(textBox_id.Text);
                }
                detalle.ID_PROD_PER = producto.ID_PRO;
                detalle.TITULO = textBox_titulo.Text;
                detalle.CONTENIDO = textBox_contenido.Text;

                if (detalle.ID_DETALLE==0)
                {
                    DetalleProductoNegocio.add(detalle);
                }
                else
                {
                    DetalleProductoNegocio.edit(detalle);
                }
                limpiarCampos();
                cargarDatos();
            }
            else
            {
                MessageBox.Show("Rellene los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public bool verificar()
        {
            if (textBox_contenido.Text=="")
            {
                return false;
            }
            if (textBox_titulo.Text == "")
            {
                return false;
            }
            return true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cargarById(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID_DETALLE"].Value.ToString()));
        }

        private void cargarById(int v)
        {
            detalle = DetalleProductoNegocio.get(v);
            textBox_id.Text = detalle.ID_DETALLE.ToString();
            textBox_titulo.Text =detalle.TITULO;
            textBox_contenido.Text = detalle.CONTENIDO;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            eliminarDetalle();
        }

        private void eliminarDetalle()
        {
            if (detalle!=null)
            {
                DetalleProductoNegocio.delete(detalle);
                cargarDatos();
            }
            else
            {
                MessageBox.Show("Seleccione un elemento", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
