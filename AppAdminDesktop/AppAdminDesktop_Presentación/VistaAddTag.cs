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
    public partial class VistaAddTag : Form
    {
        ProductoEntidad producto;
        TagEntidad tag;
        public VistaAddTag()
        {
            InitializeComponent();
        }
        public VistaAddTag(ProductoEntidad producto)
        {
            InitializeComponent();
            this.producto = producto;
            cargarDatos();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cargarById(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID_TAG"].Value.ToString()));
        }

        private void cargarById(int v)
        {
            tag = TagNegocio.get(v);
            textBox_id.Text = (tag.ID_TAG).ToString();
            textBox_tag.Text = tag.TAG;
        }
        public bool verificar()
        {
            if (textBox_tag.Text=="")
            {
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            guardar();
        }
        private void limpiar()
        {
            textBox_id.Text = "";
            textBox_tag.Text = "";
            tag = null;
        }
        private void guardar()
        {
            if (verificar())
            {
                tag =new  TagEntidad();
                if (textBox_id.Text=="")
                {
                    tag.ID_TAG = 0;
                }
                else
                {
                    tag.ID_TAG = int.Parse(textBox_id.Text);
                }
                tag.ID_PRO_PER = producto.ID_PRO;
                tag.TAG = textBox_tag.Text;
                if (tag.ID_TAG==0)
                {
                    TagNegocio.add(tag);
                }
                else
                {
                    TagNegocio.edit(tag);
                }
                limpiar();
                cargarDatos();

            }
            else
            {
             MessageBox.Show("Rellene los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cargarDatos()
        {
            dataGridView1.DataSource = TagNegocio.getByProductID(producto.ID_PRO);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            limpiar();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            eliminar();
            
        }

        private void eliminar()
        {
            if (tag != null)
            {
                TagNegocio.delete(tag);
                limpiar();
                cargarDatos();
            }
            else
            {
                MessageBox.Show("Seleccione un elemento", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
