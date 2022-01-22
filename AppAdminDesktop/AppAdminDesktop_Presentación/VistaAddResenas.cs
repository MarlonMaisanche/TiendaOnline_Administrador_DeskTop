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
    public partial class VistaAddResenas : Form
    {
        private ProductoEntidad producto;
        ResenaEntidad resena;
        VistaUsuarios vistaUsuarios;

        public VistaAddResenas()
        {
            InitializeComponent();
        }

        public VistaAddResenas(ProductoEntidad producto)
        {
            InitializeComponent();
            this.producto = producto;
            cargarDatos();
            bloquearBotones();
        }

        private void bloquearBotones()
        {
            button_add_image.Enabled = false;
        }
        private void desbloquearBotones()
        {
            button_add_image.Enabled = true;
        }

        private void cargarDatos()
        {
            dataGridView1.DataSource = ResenaNegocio.getByProductID(producto.ID_PRO);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            bloquearBotones();
            resena = null;
            textBox_id.Text = "";
            textBox_id_usuario.Text = "";
            textBox_titulo.Text = "";
            textBox_comentario.Text = "";
            textBox_estado.Text = "";
            textBox_valoracion.Text = "";
        }
        private bool verificar()
        {
            if(textBox_id_usuario.Text == "")
            {
                return false;
            }
            if (textBox_titulo.Text == "")
            {
                return false;
            }
            if (textBox_comentario.Text == "")
            {
                return false;
            }
            if (textBox_estado.Text == "")
            {
                return false;
            }
            if (textBox_valoracion.Text == "")
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
                resena = new ResenaEntidad();
                if (textBox_id.Text == "")
                {
                    resena.ID_RESE = 0;
                }
                else
                {
                    resena.ID_RESE = int.Parse(textBox_id.Text);
                }
                resena.ID_PROD_PER = producto.ID_PRO;
                resena.ID_USU_ESCR = int.Parse(textBox_id_usuario.Text);
                resena.TITULO = textBox_titulo.Text;
                resena.COMENTARIO = textBox_comentario.Text;
                resena.VALORACION = double.Parse(textBox_valoracion.Text);
                resena.ESTADO = int.Parse(textBox_estado.Text);
                resena.FECHA = dateTimePicker_fecha.Value;
                if (resena.ID_RESE==0)
                {
                   resena= ResenaNegocio.add(resena);
                    textBox_id.Text = resena.ID_RESE.ToString();
                    
                }
                else
                {
                    ResenaNegocio.edit(resena);
                }
                limpiar();
                cargarDatos();
               
            }
            else
            {
                MessageBox.Show("Rellene los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cargarPorId(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID_RESE"].Value.ToString()));
            
        }

        private void cargarPorId(int id)
        {
            resena = ResenaNegocio.get(id);
            textBox_id.Text = resena.ID_RESE.ToString();
            textBox_id_usuario.Text = resena.ID_USU_ESCR.ToString();
            textBox_titulo.Text = resena.TITULO.ToString();
            textBox_comentario.Text = resena.COMENTARIO.ToString();
            textBox_estado.Text = resena.ESTADO.ToString();
            textBox_valoracion.Text = resena.VALORACION.ToString();
            dateTimePicker_fecha.Value = (DateTime)resena.FECHA;
            desbloquearBotones();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            eliminar();
        }

        private void eliminar()
        {
            if (resena != null)
            {
                ResenaNegocio.delete(resena);
                limpiar();
                cargarDatos();
            }
            else
            {
                MessageBox.Show("Seleccione un elemento", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        internal void seleccionarUsuarioResena()
        {
            UsuarioEntidad usuario = vistaUsuarios.usuario;
            textBox_id_usuario.Text = usuario.ID_USUARIO.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            seleccionarUsuario();
        }

        private void seleccionarUsuario()
        {
            vistaUsuarios = new VistaUsuarios(this);
            vistaUsuarios.Show();
        }

        private void button_add_image_Click(object sender, EventArgs e)
        {
            VistaAddImagenes vista = new VistaAddImagenes(resena);
            vista.Show();
        }
    }
}
