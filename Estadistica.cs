using Entidades;
using System;
using System.Windows.Forms;

namespace Hamer.Thomas.SegundoParcial
{
    public partial class Estadistica : Form
    {
        #region Atributos

        private BaseDeDatos ado = new BaseDeDatos();
        private Estadisticas estadistica = new Estadisticas();
        private int id;
        private double partidasGanadas;
        private double partidasJugadas;
        private double porcentaje;
        private Usuarios usuario = new Usuarios();
        private string usuarioIngresado;

        #endregion Atributos

        #region Constructor

        public Estadistica()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Propiedades

        public int Id { get => id; set => id = value; }
        public double PartidasGanadas { get => partidasGanadas; set => partidasGanadas = value; }
        public double PartidasJugadas { get => partidasJugadas; set => partidasJugadas = value; }
        public double Porcentaje { get => porcentaje; set => porcentaje = value; }
        public string UsuarioIngresado { get => usuarioIngresado; set => usuarioIngresado = value; }

        #endregion Propiedades

        #region Metodos

        /// <summary>
        /// La Metodo cierra el formulario actual cuando se hace clic en el botón "Volver".
        /// </summary>
        /// <param name="sender">El objeto que generó el evento. En este caso, es el botón en el que se
        /// hizo clic (btnVolver).</param>
        /// <param name="EventArgs">EventArgs es una clase en C# que proporciona datos para un evento.
        /// No contiene datos, pero se utiliza como clase base para las clases que proporcionan datos de
        /// eventos. En este fragmento de código específico, EventArgs se usa como un parámetro para el
        /// método del controlador de eventos btnVolver_Click, que se llama cuando</param>
        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Esta Metodo muestra al usuario un cuadro de mensaje que le pregunta si desea cerrar el
        /// programa y cancela el evento de cierre si el usuario selecciona "No".
        /// </summary>
        /// <param name="sender">El objeto que generó el evento, en este caso, el formulario
        /// Estadistica.</param>
        /// <param name="FormClosingEventArgs">Es un argumento de evento que se pasa al controlador de
        /// eventos FormClosing. Contiene información sobre el evento y permite al controlador cancelar
        /// el cierre del formulario si es necesario.</param>
        /// <returns>
        /// Si el usuario selecciona "No" en el cuadro de mensaje, el controlador de eventos establece
        /// la propiedad `e.Cancel` en `true`, lo que significa que el evento de cierre del formulario
        /// se cancelará y el formulario permanecerá abierto. Si el usuario selecciona "Sí" o cierra el
        /// cuadro de mensaje, el controlador de eventos no devuelve nada de forma explícita.
        /// </returns>
        private void Estadistica_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.Cancel)
            {
                if (MessageBox.Show("Deseas Cerrar La Ventana?", "Salir",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                {
                    Dispose();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// Esta Metodo carga y muestra estadísticas de un usuario, incluido su nombre de usuario, la
        /// cantidad de juegos ganados y jugados y su porcentaje de ganancias.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="EventArgs">EventArgs es una clase en C# que proporciona datos para un evento.
        /// Se utiliza como clase base para clases que representan datos de eventos. En este código
        /// específico, el método Estadistica_Load es un controlador de eventos para el evento Load de
        /// un formulario, y el parámetro EventArgs se pasa automáticamente por el</param>
        private void Estadistica_Load(object sender, EventArgs e)
        {
            usuario.NombreUsuario = usuarioIngresado;
            id = ado.ObtenerIDUsuario(usuario);
            estadistica = ado.SelectById(id);
            partidasGanadas = estadistica.PartidasGanadas;
            partidasJugadas = estadistica.PartidasJugadas;
            lblNombreUsuario.Text = UsuarioIngresado;
            lblPartidasGanadas.Text = partidasGanadas.ToString();
            lblPartidasJugadas.Text = partidasJugadas.ToString();
            porcentaje = (partidasGanadas / partidasJugadas) * 100;
            lblPorcentaje.Text = porcentaje.ToString() + "%";
        }

        #endregion Metodos
    }
}