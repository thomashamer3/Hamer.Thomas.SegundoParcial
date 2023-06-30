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
        private AdoUsuarios adoUsu = new AdoUsuarios();
        private bool poderCerrar = false;

        #endregion Atributos

        #region Constructor

        public FormLogin()
        {
            InitializeComponent();
            this.AcceptButton = btn_Aceptar;
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
            List<Usuarios> lista = adoUsu.Selecionar();

            Usuarios usuarioEncontrado = null;
            bool claveCorrecta = false;

            foreach (Usuarios item in lista)
            {
                if (item.NombreUsuario == txtUsuario.Text)
                {
                    usuarioEncontrado = item;

                    if (item.Clave == txtClave.Text)
                    {
                        claveCorrecta = true;
                        break;
                    }
                }
            }

            if (claveCorrecta)
            {
                SalasPartida FormularioSalas = new SalasPartida();
                FormularioSalas.usuarioIngresado = usuarioEncontrado;
                FormularioSalas.ShowDialog();
                Hide();
            }
            else if (usuarioEncontrado != null)
            {
                lblIncorrecto.Text = "Clave Incorrecta";
                lblIncorrecto.Visible = true;
            }
            else
            {
                lblIncorrecto.Text = "Usuario y Clave No Registrados";
                lblIncorrecto.Visible = true;
            }
        }

        /// <summary>
        /// Esta función abre un formulario de registro cuando se hace clic en el botón "Registrarse".
        /// </summary>
        /// <param name="sender">El objeto que generó el evento, en este caso, el botón
        /// "btn_Registrarse".</param>
        /// <param name="EventArgs">EventArgs es una clase en C# que proporciona datos para un evento.
        /// No contiene datos, pero se utiliza como clase base para las clases que proporcionan datos de
        /// eventos. En este fragmento de código específico, EventArgs se usa como un parámetro para el
        /// método del controlador de eventos btn_Registrarse_Click, que se llama</param>
        private void btn_Registrarse_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas registrar el usuario?",
                "Confirmar registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Usuarios newUser = new Usuarios();
                newUser.NombreUsuario = txtUsuario.Text;
                newUser.Clave = txtClave.Text;

                List<Usuarios> lista = adoUsu.Selecionar();
                bool usuarioExistente = false;
                bool claveExistente = false;

                foreach (Usuarios item in lista)
                {
                    if (item.NombreUsuario == newUser.NombreUsuario)
                    {
                        usuarioExistente = true;

                        if (item.Clave == newUser.Clave)
                        {
                            claveExistente = true;
                            break;
                        }
                    }
                }

                if (claveExistente && usuarioExistente)
                {
                    lblIncorrecto.Text = "El Usuario y la Clave ya están Registrados. Utilice otros datos.";
                }
                else if (usuarioExistente)
                {
                    lblIncorrecto.Text = "Este Usuario ya está Registrado. Utilice otro Nombre de Usuario.";
                }
                else
                {
                    Estadisticas newEstadistica = new Estadisticas();
                    newEstadistica.NombreUsuario = txtUsuario.Text;

                    ado.AgregarEstadistica(newEstadistica);
                    ado.AgregarDato(newUser);
                    lblIncorrecto.Text = "Usuario y Clave Registrados correctamente.";
                }

                lblIncorrecto.Visible = true;
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

        #endregion Metodos

        /// <summary>
        /// La función comprueba si se puede establecer una conexión con una base de datos y muestra un
        /// mensaje en consecuencia.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento, en este caso, FormLogin.</param>
        /// <param name="EventArgs">EventArgs es una clase en C# que proporciona datos para un evento. A
        /// menudo se utiliza como parámetro para los controladores de eventos. En este fragmento de
        /// código específico, el método FormLogin_Load es un controlador de eventos para el evento Load
        /// de un formulario y el parámetro EventArgs no se usa en el método.</param>
        private void FormLogin_Load(object sender, EventArgs e)
        {
            BaseDeDatos ado = new BaseDeDatos();

            if (ado.ProbarConexion() == false)
            {
                MessageBox.Show("No se pudo Conectar a La Base de Datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(0);
            }
        }
    }
}