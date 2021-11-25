using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPS_PAVI.AccesoADatos;
using TPS_PAVI.Formularios;

namespace TPS_PAVI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtNombreUsuario.Focus();
        }

        private void chkMostrarContraseña_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMostrarContraseña.Checked == true)
            {
                if (txtContraseña.PasswordChar == '*')
                {
                    txtContraseña.PasswordChar = '\0';
                }
            }
            else
            {
                txtContraseña.PasswordChar = '*';
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtNombreUsuario.Text.Equals("") || txtContraseña.Text.Equals(""))
            {
                MessageBox.Show("Ingrese nombre de usuario y contraseña","Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombreUsuario.Focus();
            }
            else
            {
                var usuario = new Usuario(txtNombreUsuario.Text, txtContraseña.Text);

                if (UsuarioDao.ValidarUsuario(usuario))
                {
                    MessageBox.Show("Usted a ingresado al sistema.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    frmPrincipal ventana = new frmPrincipal();
                    ventana.ShowDialog();

                    this.Close();
                }
                else
                {
                    txtNombreUsuario.Text = "";
                    txtContraseña.Text = "";
                    MessageBox.Show("Debe ingresar usuario y/o contraseña válidos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNombreUsuario.Focus();
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult alerta = MessageBox.Show("¿Está seguro que desea salir?", "alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (alerta == DialogResult.OK)
            {
                Environment.Exit(0);
            }
        }
    }
}
