using Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Hamer.Thomas.SegundoParcial
{
    public partial class FormLogin : Form
    {
        #region Atributos

        private BaseDeDatos ado = new BaseDeDatos();
        private bool poderCerrar = false;

        #endregion Atributos

        #region Constructor

        public FormLogin()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Metodos

        /// <summary>
        /// Esta Metodo verifica si el nombre de usuario y la contraseña ingresados coinciden con los
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
                    break;
                }
            }
        }

        private void btn_Registrarse_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro();
            registro.ShowDialog();
        }

        /// <summary>
        /// Esta Metodo solicita al usuario que confirme si desea cerrar la aplicación y cancela el
        /// evento de cierre si el usuario elige no cerrarla.
        /// </summary>
        /// <param name="sender">El objeto que provocó el evento, en este caso, el formulario
        /// FormLogin.</param>
        /// <param name="FormClosingEventArgs">Este es un argumento de evento que se pasa al controlador
        /// de eventos FormClosing. Contiene información sobre el evento, como si el usuario o el código
        /// están cerrando el formulario, y permite que el controlador de eventos cancele el cierre del
        /// formulario si es necesario.</param>
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

        #endregion Metodos
    }
}