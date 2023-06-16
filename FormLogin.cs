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
        private string usuarioIngresado;

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
                }
            }
        }

        /// <summary>
        /// La Metodo registra un nuevo usuario y sus estadísticas si aún no están registrados.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento (en este caso, el botón
        /// "btn_Registrarse").</param>
        /// <param name="EventArgs">EventArgs es una clase en C# que proporciona datos para un evento.
        /// No contiene datos, pero se utiliza como clase base para las clases que proporcionan datos de
        /// eventos. En este caso, se utiliza como parámetro para el método del controlador de eventos
        /// btn_Registrarse_Click, que se activa cuando el</param>
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

        /// <summary>
        /// La Metodo oculta una etiqueta para un usuario registrado en el formulario de inicio de
        /// sesión cuando se carga.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento, en este caso, FormLogin.</param>
        /// <param name="EventArgs">EventArgs es una clase en C# que proporciona datos para un evento.
        /// Se utiliza para pasar información sobre un evento que ha ocurrido, como el remitente del
        /// evento, los argumentos del evento y cualquier dato adicional que pueda ser necesario. En
        /// este fragmento de código específico, el parámetro EventArgs no se está</param>
        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.lblUsuarioRegistrado.Visible = false;
        }

        #endregion Metodos
    }
}