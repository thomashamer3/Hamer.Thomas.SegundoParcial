using Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Hamer.Thomas.SegundoParcial
{
    public partial class FormLogin : Form
    {
        private BaseDeDatos ado = new BaseDeDatos();
        private bool poderCerrar = false;
        private string usuarioIngresado;

        public FormLogin()
        {
            InitializeComponent();
        }

        public string UsuarioIngresado { get => usuarioIngresado; set => usuarioIngresado = value; }

        /// <summary>
        /// Esta función verifica si el nombre de usuario y la contraseña ingresados coinciden con los
        /// almacenados en la base de datos y abre un nuevo formulario si coinciden; de lo contrario,
        /// muestra un mensaje de error.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento, en este caso, el botón
        /// "btn_Aceptar".</param>
        /// <param name="EventArgs">EventArgs es una clase en C# que proporciona datos para un evento.
        /// Se utiliza como clase base para clases que representan datos de eventos. En este código
        /// específico, el parámetro EventArgs no se usa, pero es necesario porque el método es un
        /// controlador de eventos para el evento Click de un botón.</param>
        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            Usuarios adoUsu = new Usuarios();
            List<Usuarios> lista = adoUsu.Selecionar();

            foreach (Usuarios item in lista)
            {
                if (item.NombreUsuario == txtUsuario.Text && item.Clave == txtClave.Text)
                {
                    SalasPartida FormularioSalas = new SalasPartida();
                    FormularioSalas.UsuarioIngresado = item;
                    FormularioSalas.ShowDialog();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Clave o Usuario Incorrectos.", "Error.");
                }
            }
        }

        private void btn_Registrarse_Click(object sender, EventArgs e)
        {
            Usuarios newUser = new Usuarios();
            List<Usuarios> lista = newUser.Selecionar();

            newUser.NombreUsuario = txtUsuario.Text;
            newUser.Clave = txtClave.Text;

            foreach (Usuarios item in lista)
            {
                if (item.NombreUsuario == txtUsuario.Text && item.Clave == txtClave.Text)
                {
                    MessageBox.Show("Usuario Ya Esta Registrado, Ingrese Otro.", "Error.");
                }
                else
                {
                    Estadisticas newEstadistica = new Estadisticas();

                    newEstadistica.NombreUsuario = txtUsuario.Text;
                    ado.AgregarEstadistica(newEstadistica);
                    ado.AgregarDato(newUser);
                    this.lblUsuarioRegistrado.Visible = true;
                }
            }
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!poderCerrar)
            {
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas cerrar la aplicación?",
                    "Confirmar cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.lblUsuarioRegistrado.Visible = false;
        }
    }
}