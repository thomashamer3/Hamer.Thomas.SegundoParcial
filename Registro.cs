using Entidades;
using System;
using System.Windows.Forms;

namespace Hamer.Thomas.SegundoParcial
{
    public partial class Registro : Form
    {
        #region Atributos

        private BaseDeDatos ado = new BaseDeDatos();

        #endregion Atributos

        #region Constructor

        public Registro()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Metodos

        /// <summary>
        /// La función crea un nuevo usuario y agrega sus estadísticas y datos a una base de datos.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento, en este caso, el botón
        /// "btn_Registrarse".</param>
        /// <param name="EventArgs">EventArgs es una clase en C# que proporciona datos para un evento.
        /// No contiene datos, pero se utiliza como clase base para todas las clases de datos de
        /// eventos. Se usa comúnmente como un parámetro para los controladores de eventos.</param>
        private void btn_Registrarse_Click(object sender, EventArgs e)
        {
            if ((txtUsuario.Text.Length > 4 && txtUsuario.Text.Length < 20) && (txtClave.Text.Length > 4 && txtClave.Text.Length < 16))
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
            else
            {
                MessageBox.Show("Clave o Usuario Incorrectos.", "Error.");
            }
        }

        /// <summary>
        /// Esta función muestra al usuario un cuadro de mensaje que le pregunta si desea cerrar el
        /// programa y cancela el evento de cierre del formulario si el usuario selecciona "No".
        /// </summary>
        /// <param name="sender">El objeto que generó el evento, en este caso, el formulario
        /// Registro.</param>
        /// <param name="FormClosingEventArgs">Es un argumento de evento que se pasa al controlador de
        /// eventos FormClosing. Contiene información sobre el evento y permite al controlador cancelar
        /// el cierre del formulario si es necesario.</param>
        /// <returns>
        /// Si el usuario selecciona "No" en el cuadro de mensaje, el controlador de eventos establece
        /// la propiedad `e.Cancel` en `true`, lo que significa que el evento de cierre del formulario
        /// se cancelará y el formulario permanecerá abierto. Si el usuario selecciona "Sí" o cierra el
        /// cuadro de mensaje, el controlador de eventos no devuelve nada de forma explícita.
        /// </returns>
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

        #endregion Metodos
    }
}