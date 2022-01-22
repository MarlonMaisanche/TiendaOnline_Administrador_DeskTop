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
    public partial class VistaColor : Form
    {
        VistaAddColores vistaAnterior;
        public ColorEntidad color;
        public VistaColor()
        {
            InitializeComponent();
        }
        public VistaColor(VistaAddColores vistaAnterior)
        {
            InitializeComponent();
            this.vistaAnterior = vistaAnterior;
            cargarDatos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();
           
        }

        private void limpiar()
        {
            color = null;
            textBox_id.Text = "";
            textBox_nombre.Text = "";
        }
        private bool verificar()
        {
            if (textBox_nombre.Text == "")
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
                color = new ColorEntidad();
                if (textBox_id.Text == "")
                {
                    color.ID_COLOR = 0;
                }
                else
                {
                    color.ID_COLOR = int.Parse(textBox_id.Text);
                }
                color.NOM_COLOR = textBox_nombre.Text;
                if (color.ID_COLOR == 0)
                {
                    ColorNegocio.add(color);
                }
                else
                {
                    ColorNegocio.edit(color);
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
            dataGridView1.DataSource = ColorNegocio.get();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limpiar();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (color != null)
            {
                ColorNegocio.delete(color);
                cargarDatos();
                limpiar();
            }
            else
            {
                MessageBox.Show("Seleccione un elemento", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (color != null)
            {
                vistaAnterior.seleccionarColor();
                limpiar();
                this.Close();
            }
            else
            {
                MessageBox.Show("Seleccione un elemento", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cargarById(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID_COLOR"].Value.ToString()));
        }

        private void cargarById(int id)
        {
            color = ColorNegocio.get(id);
            textBox_id.Text = color.ID_COLOR.ToString();
            textBox_nombre.Text = color.NOM_COLOR;
        }
    }
}
