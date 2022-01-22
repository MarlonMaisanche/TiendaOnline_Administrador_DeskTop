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
    public partial class VistaUsuarios : Form
    {
        VistaAddResenas vistaAnterior;
        public UsuarioEntidad usuario;
        public VistaUsuarios()
        {
            InitializeComponent();
            cargarDatos();
            bloquearInput();
        }

        private void cargarDatos()
        {
            dataGridView1.DataSource = UsuarioNegocio.get();
        }

        public VistaUsuarios(VistaAddResenas vistaAnterior)
        {
            InitializeComponent();
            this.vistaAnterior = vistaAnterior;
            cargarDatos();
            bloquearInput();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            usuario = null;
            textBox_id.Text = "";
            textBox_correo.Text = "";
            textBox_contrasena.Text = "";
            textBox_nombre.Text = "";
            textBox_apellido.Text = "";
            textBox_cedula.Text = "";
            textBox_val_user.Text = "";
            textBox_estado.Text = "";
            textBox_telefono.Text = "";
            bloquearInput();
        }
        private void bloquearInput()
        {
            textBox_apellido.Enabled = false;
            textBox_cedula.Enabled = false;
            textBox_val_user.Enabled = false;
            textBox_estado.Enabled = false;
            textBox_telefono.Enabled = false;
        }
        private void desbloquearInput()
        {
            textBox_apellido.Enabled = true;
            textBox_cedula.Enabled = true;
            textBox_val_user.Enabled = true;
            textBox_estado.Enabled = true;
            textBox_telefono.Enabled = true;
        }
        private bool verificar()
        {
            if (textBox_correo.Text == "")
            {
                return false;
            }
            if (textBox_contrasena.Text == "")
            {
                return false;
            }
            if (textBox_nombre.Text == "")
            {
                return false;
            }
           
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            addOrUpdate();
        }

        private void addOrUpdate()
        {
            if (verificar())
            {
                if (usuario == null)
                {
                    guardar();
                }
                else
                {
                    actualizar();
                }
                limpiar();
                cargarDatos();
               
            }
            else
            {
               
            }
           
        }

        private void guardar()
        {
            usuario = new UsuarioEntidad();
            usuario.ID_USUARIO = 0;
            usuario.CORREO = textBox_correo.Text;
            usuario.PASS = textBox_contrasena.Text;
            usuario.NOMBRE= textBox_nombre.Text;
            usuario.APELLIDO = "NA";
            usuario.CEDULA = "NA";
            usuario.ID_GENERO = null;
            usuario.TELEFONO = "NA";
            usuario.VAL_USU = 0;
            usuario.FEC_CREA = DateTime.Now;
            usuario.ESTADO = 1;
            usuario.ID_DIR_PRI = null;
           usuario= UsuarioNegocio.add(usuario);

        }

        private void actualizar()
        {
            usuario.CORREO = textBox_correo.Text;
            usuario.PASS = textBox_contrasena.Text;
            usuario.NOMBRE = textBox_nombre.Text;
            usuario.APELLIDO = textBox_apellido.Text;
            usuario.CEDULA = textBox_cedula.Text;
            usuario.TELEFONO = textBox_telefono.Text;
            usuario.VAL_USU = double.Parse(textBox_val_user.Text);
            usuario.ESTADO = int.Parse(textBox_estado.Text);
            UsuarioNegocio.edit(usuario);
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
            if (usuario != null)
            {
                UsuarioNegocio.delete(usuario);
                limpiar();
                cargarDatos();
            }
            else
            {
                MessageBox.Show("Seleccione un elemento", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            seleccionarUsuario();
        }

        private void seleccionarUsuario()
        {
            if (vistaAnterior != null)
            {
                if (usuario != null)
                {
                    vistaAnterior.seleccionarUsuarioResena();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Seleccione un elemento", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cargarById(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID_USUARIO"].Value.ToString()));
            desbloquearInput();
        }

        private void cargarById(int id)
        {
            usuario = UsuarioNegocio.get(id);
            textBox_id.Text = usuario.ID_USUARIO.ToString();
            textBox_correo.Text = usuario.CORREO.ToString();
            textBox_contrasena.Text = usuario.PASS.ToString();
            textBox_nombre.Text = usuario.NOMBRE.ToString();
            textBox_apellido.Text = usuario.APELLIDO.ToString();
            textBox_cedula.Text = usuario.CEDULA.ToString();
            textBox_val_user.Text = usuario.VAL_USU.ToString();
            textBox_estado.Text = usuario.ESTADO.ToString();
            textBox_telefono.Text = usuario.TELEFONO.ToString();
        }
    }
}
