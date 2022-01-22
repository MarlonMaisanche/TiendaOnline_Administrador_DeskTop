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
    public partial class VistaTallas : Form
    {
        VistaAddTallas vistaAnterior;
        public TallaEntidad talla;
        public VistaTallas()
        {
            InitializeComponent();
            cargarDatos();
            
        }
        public VistaTallas(VistaAddTallas vistaAnterior)
        {
            InitializeComponent();
            this.vistaAnterior = vistaAnterior;
            cargarDatos();
        }

        private void cargarDatos()
        {
            dataGridView1.DataSource = TallaNegocio.get();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cargarById(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID_TALLA"].Value.ToString()));

        }

        private void cargarById(int id)
        {
            talla = TallaNegocio.get(id);
            textBox_id.Text = talla.ID_TALLA.ToString();
            textBox_nombre.Text = talla.NOM_TALLA.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void guardar()
        {
            if (verificar())
            {
                talla = new TallaEntidad();
                if (textBox_id.Text=="")
                {
                    talla.ID_TALLA = 0;
                }
                else
                {
                    talla.ID_TALLA=int.Parse(textBox_id.Text);
                }
                talla.NOM_TALLA = textBox_nombre.Text;
                if (talla.ID_TALLA==0)
                {
                    TallaNegocio.add(talla);
                }
                else
                {
                    TallaNegocio.edit(talla);
                }
                cargarDatos();
                limpiar();
            }
            else
            {
                MessageBox.Show("Rellene los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            talla = null;
            textBox_id.Text = "";
            textBox_nombre.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limpiar();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            eliminar();
        }
        private bool verificar()
        {
            if (textBox_nombre.Text=="")
            {
                return false;
            }
                return true;
        }
        private void eliminar()
        {
            if (talla != null)
            {
                TallaNegocio.delete(talla);
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
            if (talla != null)
            {
                vistaAnterior.seleccionarTalla();
                limpiar();
                this.Close();
            }
            else
            {
                MessageBox.Show("Seleccione un elemento", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
