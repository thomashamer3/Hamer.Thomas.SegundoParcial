using Entidades;
using System;
using System.Windows.Forms;

namespace Hamer.Thomas.SegundoParcial
{
    public partial class Registro : Form
    {
        private BaseDeDatos ado = new BaseDeDatos();

        public Registro()
        {
            InitializeComponent();
        }

        private void btn_Registrarse_Click(object sender, EventArgs e)
        {
            Usuarios newUser = new Usuarios();
            newUser.NombreUsuario = txtUsuario.Text;
            newUser.Clave = txtClave.Text;

            Estadisticas newEstadistica = new Estadisticas();

            newEstadistica.NombreUsuario = txtUsuario.Text;
            ado.AgregarEstadistica(newEstadistica);
            ado.AgregarDato(newUser);
            Hide();
        }

        private void Registro_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Desea cerrar el programa?",
                  "Advertencia", MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
        }
    }
}