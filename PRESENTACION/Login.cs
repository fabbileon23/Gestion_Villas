using LOGICA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRESENTACION
{
    public partial class menu_Bienvenida : Form
    {

        Logica_Presentacion logica_Presentacion = new Logica_Presentacion();
        public menu_Bienvenida()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            errorProvider1.Clear();
            if (txtContrasena.Text == "") {
                errorProvider1.SetError(txtContrasena, "Debes de escribir una contraseña");
                return;
            }

            if (logica_Presentacion.evaluarContraseña(txtContrasena.Text) == false)
            {
                errorProvider1.SetError(txtContrasena, "Contraseña incorrecta");
            }
            else 
            { 
                MenuPrincipal menuPrincipal = new MenuPrincipal();
                menuPrincipal.Show();
                this.Hide();
            }

            }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtContrasena.UseSystemPasswordChar = false;
            }
            else
            {
                txtContrasena.UseSystemPasswordChar = true;
            }
        }

        private void menu_Bienvenida_Load(object sender, EventArgs e)
        {
            
        }

        private void menu_Bienvenida_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
