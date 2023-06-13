using System;
using System.Windows.Forms;

namespace Hamer.Thomas.SegundoParcial
{
    public partial class FormLogin : Form
    {
        private string UsuarioIngresado;

        public FormLogin()
        {
            InitializeComponent();
        }

        public string UsuarioIngresado1 { get => UsuarioIngresado; set => UsuarioIngresado = value; }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
        }
    }
}