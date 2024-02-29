using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ENTIDADES;
using LOGICA;

namespace PRESENTACION
{
    public partial class MenuPrincipal : Form
    {
        Logica_Villa logica_villa = new Logica_Villa();
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            if (logica_villa.ParseInt(txtId.Text) == false)
            {
                errorProvider1.SetError(txtId, "El valor del campo ID es incorrecto");
                return;
            }

            if (logica_villa.ParseInt(txtHabitantes.Text) == false)
            {
                errorProvider1.SetError(txtHabitantes, "El valor del campo habitantes es incorrecto");
                return;
            }

            if (logica_villa.ParseDecimal(txtArea.Text) == false)
            {
                errorProvider1.SetError(txtArea, "El valor del campo área es incorrecto");
                return;
            }
          
            if (logica_villa.ParseDecimal(txtPrecio.Text) == false)
            {
                errorProvider1.SetError(txtPrecio, "El valor del campo precio es incorrecto");
                return;
            }

            if (logica_villa.VillaExistente(Convert.ToInt32(txtId.Text)) == true)
            {
                errorProvider1.SetError(txtId, "El Id ya existe");
                return;

            }



            logica_villa.crearVilla(new Villa(Convert.ToInt32(txtId.Text), txtNombre.Text, Convert.ToInt32(txtHabitantes.Text), Convert.ToDecimal(txtArea.Text), Convert.ToDecimal(txtPrecio.Text)));

            dgvVillas.DataSource = null;
            dgvVillas.DataSource = logica_villa.getVillas();

            txtId.Clear();
            txtNombre.Clear();
            txtHabitantes.Clear();
            txtArea.Clear();
            txtPrecio.Clear();  
            txtId.Focus();


        }

        private void dgvVillas_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtId.ReadOnly = true;
            txtId.Text = dgvVillas.SelectedRows[0].Cells[0].Value.ToString();
            txtNombre.Text = dgvVillas.SelectedRows[0].Cells[1].Value.ToString();
            txtHabitantes.Text = dgvVillas.SelectedRows[0].Cells[2].Value.ToString();
            txtArea.Text = dgvVillas.SelectedRows[0].Cells[3].Value.ToString();
            txtPrecio.Text = dgvVillas.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            errorProvider1.Clear();

            if (logica_villa.ParseInt(txtId.Text) == false)
            {
                errorProvider1.SetError(txtId, "El valor del campo ID es incorrecto");
                return;
            }

            if (logica_villa.ParseInt(txtHabitantes.Text) == false)
            {
                errorProvider1.SetError(txtHabitantes, "El valor del campo habitantes es incorrecto");
                return;
            }

            if (logica_villa.ParseDecimal(txtArea.Text) == false)
            {
                errorProvider1.SetError(txtArea, "El valor del campo área es incorrecto");
                return;
            }

            if (logica_villa.ParseDecimal(txtPrecio.Text) == false)
            {
                errorProvider1.SetError(txtPrecio, "El valor del campo precio es incorrecto");
                return;
            }

            logica_villa.ActualizarVilla(new Villa(Convert.ToInt32(txtId.Text), txtNombre.Text, Convert.ToInt32(txtHabitantes.Text), Convert.ToDecimal(txtArea.Text), Convert.ToDecimal(txtPrecio.Text)));

            dgvVillas.DataSource = null;
            dgvVillas.DataSource = logica_villa.getVillas();

            txtId.Clear();
            txtNombre.Clear();
            txtHabitantes.Clear();
            txtArea.Clear();
            txtPrecio.Clear();
            txtId.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            errorProvider1.Clear();


            if (logica_villa.ParseInt(txtId.Text) == false)
            {
                errorProvider1.SetError(txtId, "Debes seleccionar una villa");
                return;
            }

            logica_villa.EliminarVilla(Convert.ToInt32(txtId.Text));

            dgvVillas.DataSource = null;
            dgvVillas.DataSource = logica_villa.getVillas();

            txtId.Clear();
            txtNombre.Clear();
            txtHabitantes.Clear();
            txtArea.Clear();
            txtPrecio.Clear();
            txtId.Focus();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if(logica_villa.ObtenerNVillas() == 0)
            {
                errorProvider1.SetError(btnReportes, "Debe de haber al menos 1 villa");
                return;
            }

            Reportes reportes = new Reportes();
            reportes.Show();

            reportes.lblNVillas.Text = Convert.ToString(logica_villa.ObtenerNVillas());
            reportes.lblNombreCostosa.Text = logica_villa.ObtenerNombreVillaCostosa();  
            reportes.lblPrecioCostosa.Text = logica_villa.ObtenerPrecioVillaCostosa();
            reportes.lblNombreBarata.Text = logica_villa.ObtenerNombreVillaBarata();
            reportes.lblPrecioBarata.Text = logica_villa.ObtenerPrecioVillaBarata();
            reportes.lblPrecioPromedio.Text = logica_villa.ObtenerPromedioPrecio();
            reportes.lblPrecioTotal.Text = logica_villa.ObtenerValorTotalVillas();
            reportes.lblTotalHabitantes.Text = logica_villa.ObtenerHabitantes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menu_Bienvenida menu_Bienvenida = new menu_Bienvenida();
            menu_Bienvenida.Show();
            this.Hide();    
        }

        private void MenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
