using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hamer.Thomas.SegundoParcial
{
    public partial class SalasPartida : Form
    {
        #region Atributos

        private BaseDeDatos ado = new BaseDeDatos();
        private List<Salas> listAux = new List<Salas>();
        private List<Salas> salas = new List<Salas>();
        private Ordenar tipoDeSort;
        public Usuarios usuarioIngresado;

        public delegate List<Salas> Ordenar(List<Salas> lstAux, int index);

        #endregion Atributos

        #region Constructor

        public SalasPartida()
        {
            InitializeComponent();
            TipoDeSort += IndexDelSort;
        }

        #endregion Constructor

        #region Propiedades

        public BaseDeDatos Ado { get => ado; set => ado = value; }
        public List<Salas> ListAux { get => listAux; set => listAux = value; }
        public List<Salas> Salas { get => salas; set => salas = value; }
        public Ordenar TipoDeSort { get => tipoDeSort; set => tipoDeSort = value; }
        public Usuarios UsuarioIngresado { get => usuarioIngresado; set => usuarioIngresado = value; }

        #endregion Propiedades

        #region Metodos

        /// <summary>
        /// La Metodo toma una lista de Salas y un índice, y devuelve la lista ordenada según el índice
        /// elegido.
        /// </summary>
        /// <param name="lstAux">Una lista de objetos de tipo "Salas".</param>
        /// <param name="index">un valor entero que representa el índice de la opción de clasificación
        /// que se aplicará a la lista de Salas.</param>
        /// <returns>
        /// El método devuelve una Lista de Salas después de ordenarla según el valor del parámetro
        /// entero "índice".
        /// </returns>
        private static List<Salas> IndexDelSort(List<Salas> lstAux, int index)
        {
            switch (index)
            {
                case 1:
                    lstAux = SortIDCreador(lstAux);
                    break;

                case 2:
                    lstAux = SortEstado(lstAux);
                    break;

                case 3:
                    lstAux = SortPtsJ1(lstAux);
                    break;

                case 4:
                    lstAux = SortPtsJ2(lstAux);
                    break;
            }
            return lstAux;
        }

        /// <summary>
        /// La Metodo ordena una lista de objetos "Salas" por su propiedad "Estado".
        /// </summary>
        /// <param name="lstAux">lstAux es una Lista de objetos de tipo Salas. Este método ordena la
        /// lista según la propiedad Estado de cada objeto Salas y devuelve la lista ordenada.</param>
        /// <returns>
        /// El método `SortEstado` devuelve una lista ordenada de objetos `Salas` en Metodo de su
        /// propiedad `Estado`.
        /// </returns>
        private static List<Salas> SortEstado(List<Salas> lstAux)
        {
            return lstAux.OrderBy(d => d.Estado).ToList();
        }

        /// <summary>
        /// Esta Metodo ordena una lista de objetos "Salas" por el nombre de su creador.
        /// </summary>
        /// <param name="lstAux">lstAux es una Lista de objetos de tipo Salas que debe ordenarse en
        /// Metodo de la propiedad CreadorNombre de cada objeto. El método SortIDCreador toma esta
        /// lista como entrada y devuelve una lista ordenada basada en la propiedad
        /// CreadorNombre.</param>
        /// <returns>
        /// El método `SortIDCreador` devuelve una lista ordenada de objetos `Salas` basada en la
        /// propiedad `CreadorNombre`.
        /// </returns>
        private static List<Salas> SortIDCreador(List<Salas> lstAux)
        {
            return lstAux.OrderBy(d => d.CreadorNombre).ToList();
        }

        /// <summary>
        /// La Metodo ordena una lista de objetos "Salas" por la propiedad "PuntosJ1" en orden
        /// descendente.
        /// </summary>
        /// <param name="lstAux">lstAux es una Lista de objetos de tipo Salas. El método SortPtsJ1 toma
        /// esta lista como entrada y la ordena de forma descendente según la propiedad PuntosJ1 de cada
        /// objeto Salas. A continuación, la lista ordenada se devuelve como salida.</param>
        /// <returns>
        /// El método `SortPtsJ1` está devolviendo una lista ordenada de objetos `Salas` basada en la
        /// propiedad `PuntosJ1` en orden descendente.
        /// </returns>
        private static List<Salas> SortPtsJ1(List<Salas> lstAux)
        {
            return lstAux.OrderByDescending(d => d.PuntosJ1).ToList();
        }

        /// <summary>
        /// La Metodo ordena una lista de objetos "Salas" por la propiedad "PuntosJ2" en orden
        /// descendente.
        /// </summary>
        /// <param name="lstAux">lstAux es una Lista de objetos de tipo Salas. El método SortPtsJ2 toma
        /// esta lista como entrada y la ordena de forma descendente según la propiedad PuntosJ2 de cada
        /// objeto Salas. A continuación, la lista ordenada se devuelve como salida.</param>
        /// <returns>
        /// El método `SortPtsJ2` está devolviendo una lista ordenada de objetos `Salas` basada en la
        /// propiedad `PuntosJ2` en orden descendente.
        /// </returns>
        private static List<Salas> SortPtsJ2(List<Salas> lstAux)
        {
            return lstAux.OrderByDescending(d => d.PuntosJ2).ToList();
        }

        /// <summary>
        /// Esta Metodo actualiza un DataGridView con datos de una lista de objetos Salas obtenidos de
        /// una base de datos, mientras muestra una pantalla de carga durante el proceso.
        /// </summary>
        /// <param name="sender">El objeto que levantó el evento, en este caso, el botón
        /// "btnActualizarSalas".</param>
        /// <param name="EventArgs">EventArgs es una clase en C# que proporciona datos para un evento.
        /// No contiene datos, pero se usa como clase base para las clases que proporcionan datos de
        /// eventos. En este fragmento de código específico, el parámetro EventArgs no se usa, pero se
        /// requiere como parte de la firma del método para el evento.</param>
        private async void btnActualizarSalas_Click(object sender, EventArgs e)
        {
            MostrarCarga();
            Task Cargando = new Task(Esperar);
            Cargando.Start();

            DGVSalas.Rows.Clear();

            salas = this.ado.ObtenerListaDatoSalas();

            foreach (Salas item in this.salas)
            {
                DGVSalas.Rows.Add(MostrarEnGrid(item));
            }

            await Cargando;
            OcultarCarga();
        }

        /// <summary>
        /// Esta Metodo borra un DataGridView y lo llena con datos de una lista de objetos Salas
        /// ordenados mediante un método de clasificación específico.
        /// </summary>
        /// <param name="sender">El objeto que levantó el evento, en este caso, el botón
        /// "btnCreadorSala".</param>
        /// <param name="EventArgs">EventArgs es una clase en C# que proporciona datos para un evento.
        /// Se utiliza para pasar información sobre un evento a un controlador de eventos. En este
        /// fragmento de código específico, el parámetro EventArgs no se usa, pero se requiere como
        /// parte de la firma del método para el controlador de eventos.</param>
        private void btnCreadorSala_Click(object sender, EventArgs e)
        {
            DGVSalas.Rows.Clear();
            listAux = TipoDeSort.Invoke(salas, 1);
            foreach (Salas item in listAux)
            {
                DGVSalas.Rows.Add(MostrarEnGrid(item));
            }
        }

        /// <summary>
        /// Esta Metodo crea un nuevo objeto "Sala" y lo agrega a la base de datos usando el objeto
        /// "ado".
        /// </summary>
        /// <param name="sender">El objeto que provocó el evento (en este caso, el botón en el que se
        /// hizo clic).</param>
        /// <param name="EventArgs">EventArgs es una clase en C# que proporciona datos para un evento.
        /// Se utiliza para pasar información sobre un evento que ha ocurrido, como un clic en un botón
        /// o el cierre de un formulario. En este fragmento de código específico, EventArgs no se usa
        /// para ningún propósito específico, pero se requiere como parámetro.</param>
        private void btnCrearSala_Click(object sender, EventArgs e)
        {
            Salas newSala = new Salas();
            newSala.Creador = ado.ObtenerIDUsuario(usuarioIngresado);

            bool agrego = ado.AgregarDatoSala(newSala);

            if (agrego)
            {
                MessageBox.Show("Se Agregó una Nueva Sala!");
            }
            else
            {
                MessageBox.Show("No se Agregó una Nueva Sala.");
            }
        }

        /// <summary>
        /// Esta Metodo abre un nuevo formulario para mostrar estadísticas relacionadas con un usuario.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento, en este caso, el botón en el que se
        /// hizo clic (btnEstadisticasUsuario).</param>
        /// <param name="EventArgs">EventArgs es una clase en C# que proporciona datos para un evento.
        /// Se utiliza para pasar información sobre un evento que ha ocurrido, como un clic en un botón
        /// o el cierre de un formulario. En este fragmento de código específico, el parámetro EventArgs
        /// no se usa, pero se requiere como parte del método.</param>
        private void btnEstadisticasUsuario_Click(object sender, EventArgs e)
        {
            Estadistica formEstadistica = new Estadistica();
            formEstadistica.UsuarioIngresado = usuarioIngresado.NombreUsuario;
            formEstadistica.ShowDialog();
        }

        /// <summary>
        /// Esta Metodo borra un DataGridView y lo llena con datos de una lista de objetos Salas
        /// ordenados por un criterio específico.
        /// </summary>
        /// <param name="sender">El objeto que levantó el evento, en este caso, el botón
        /// "btnEstadoSala".</param>
        /// <param name="EventArgs">EventArgs es una clase en C# que proporciona datos para un evento.
        /// Se utiliza para pasar información sobre un evento a un controlador de eventos. En este
        /// fragmento de código específico, el parámetro EventArgs no se usa, pero se requiere como
        /// parte de la firma del método para el controlador de eventos.</param>
        private void btnEstadoSala_Click(object sender, EventArgs e)
        {
            DGVSalas.Rows.Clear();
            listAux = TipoDeSort.Invoke(salas, 2);
            foreach (Salas item in listAux)
            {
                DGVSalas.Rows.Add(MostrarEnGrid(item));
            }
        }

        /// <summary>
        /// Esta Metodo borra un DataGridView y lo llena con datos de una lista de objetos "Salas"
        /// ordenados por un tipo específico.
        /// </summary>
        /// <param name="sender">El objeto que levantó el evento, en este caso, el botón
        /// "btnPuntosJugadorDos".</param>
        /// <param name="EventArgs">EventArgs es una clase en C# que proporciona datos para un evento.
        /// Se utiliza para pasar información sobre un evento a un controlador de eventos. En este
        /// fragmento de código específico, el parámetro EventArgs no se usa, pero se requiere como
        /// parte de la firma del método para el controlador de eventos.</param>
        private void btnPuntosJugadorDos_Click(object sender, EventArgs e)
        {
            DGVSalas.Rows.Clear();
            listAux = TipoDeSort.Invoke(salas, 4);
            foreach (Salas item in listAux)
            {
                DGVSalas.Rows.Add(MostrarEnGrid(item));
            }
        }

        /// <summary>
        /// Esta Metodo borra un DataGridView y lo llena con datos de una lista de objetos ordenados
        /// por un tipo específico.
        /// </summary>
        /// <param name="sender">El objeto que levantó el evento, en este caso, el botón
        /// "btnPuntosJugadorUno".</param>
        /// <param name="EventArgs">EventArgs es una clase en C# que proporciona datos para un evento.
        /// Se utiliza para pasar información sobre un evento a un controlador de eventos. En este
        /// fragmento de código específico, el parámetro EventArgs no se usa, pero se requiere como
        /// parte de la firma del método para el controlador de eventos.</param>
        private void btnPuntosJugadorUno_Click(object sender, EventArgs e)
        {
            DGVSalas.Rows.Clear();
            listAux = TipoDeSort.Invoke(salas, 3);
            foreach (Salas item in listAux)
            {
                DGVSalas.Rows.Add(MostrarEnGrid(item));
            }
        }

        /// <summary>
        /// Esta Metodo establece las propiedades de un objeto Juego en Metodo de la fila seleccionada
        /// en un DataGridView y muestra el objeto Juego en una ventana de diálogo.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento, en este caso, el control
        /// DataGridView.</param>
        /// <param name="DataGridViewCellEventArgs">Un argumento de evento que contiene información
        /// sobre la celda en la que se hizo clic en un control DataGridView.</param>
        private void DGVSalas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Juego juego = new Juego();

            juego.CreadorNombre = DGVSalas.CurrentRow.Cells["nombreUsuario"].Value.ToString();
            juego.IdSala = Convert.ToInt32(DGVSalas.CurrentRow.Cells["ID"].Value);
            juego.J1Puntos = Convert.ToInt32(DGVSalas.CurrentRow.Cells["PuntosJ1"].Value);
            juego.J2Puntos = Convert.ToInt32(DGVSalas.CurrentRow.Cells["PuntosJ2"].Value);
            juego.ContadorTurnos = Convert.ToInt32(DGVSalas.CurrentRow.Cells["TurnosRestantes"].Value);
            juego.EstadoSala = DGVSalas.CurrentRow.Cells["estado"].Value.ToString();
            juego.TiempoDePartida = DGVSalas.CurrentRow.Cells["TiempoDePartida"].Value.ToString();
            juego.IdCreador = Convert.ToInt32(DGVSalas.CurrentRow.Cells["IdCreador"].Value);

            juego.ShowDialog();
        }

        /// <summary>
        /// La Metodo Esperar espera 3 segundos antes de continuar con la ejecución.
        /// </summary>
        private void Esperar()
        {
            Thread.Sleep(3000);
        }

        /// <summary>
        /// La Metodo "MostrarCarga" muestra una pantalla de carga al hacer visible un cuadro de imagen
        /// y llenarlo al tamaño de la pantalla.
        /// </summary>
        private void MostrarCarga()
        {
            pictureBoxPantallaDeCarga.Dock = DockStyle.Fill;
            pictureBoxPantallaDeCarga.Visible = true;
        }

        /// <summary>
        /// La Metodo "MostrarEnGrid" devuelve una matriz de cadenas que contienen información sobre un
        /// objeto "Salas" para mostrar en una cuadrícula.
        /// </summary>
        /// <param name="Salas">Parece que "Salas" es una clase o estructura de datos que contiene
        /// información sobre una sala de juegos o un lobby. El método "MostrarEnGrid" toma una
        /// instancia de esta clase como entrada y devuelve una matriz de cadenas que representan la
        /// información de la sala de juegos en formato de cuadrícula. El retorno</param>
        /// <returns>
        /// El método devuelve una matriz de cadenas que contiene información sobre un objeto "Salas",
        /// incluido el nombre del creador, el estado de la sala, los puntos del jugador 1 y el jugador
        /// 2, los turnos restantes del jugador 1, el tiempo restante del jugador 1, el ID de la sala y
        /// el ID del creador.
        /// </returns>
        private string[] MostrarEnGrid(Salas sala)
        {
            string[] fila = {
                sala.CreadorNombre.ToString(),
                sala.Estado,
                sala.PuntosJ1.ToString(),
                sala.PuntosJ2.ToString(),
                sala.TurnosRestantes1.ToString(),
                sala.TiempoDePartida1.ToString(),
                sala.IDSala.ToString(),
                sala.Creador.ToString()
                };

            return fila;
        }

        /// <summary>
        /// La Metodo oculta una pantalla de carga configurando el estilo de base del cuadro de imagen
        /// en ninguno y su visibilidad en falso.
        /// </summary>
        private void OcultarCarga()
        {
            pictureBoxPantallaDeCarga.Dock = DockStyle.None;
            pictureBoxPantallaDeCarga.Visible = false;
        }

        /// <summary>
        /// La Metodo Salas_Load establece el texto de una etiqueta y llena un DataGridView con datos
        /// de una lista de objetos Salas.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento. En este caso, es la forma
        /// "Salas".</param>
        /// <param name="EventArgs">EventArgs es una clase en C# que proporciona datos para un evento.
        /// Se utiliza como clase base para clases que representan datos de eventos. No contiene datos,
        /// pero se usa como parámetro para los controladores de eventos para indicar que no se
        /// necesitan datos adicionales para el evento.</param>
        private void Salas_Load(object sender, EventArgs e)
        {
            lblNombreUsuario.Text = usuarioIngresado.NombreUsuario;
            salas = this.ado.ObtenerListaDatoSalas();
            foreach (Salas item in this.salas)
            {
                DGVSalas.Rows.Add(MostrarEnGrid(item));
            }
        }

        /// <summary>
        /// Esta Metodo muestra al usuario un cuadro de mensaje que le pregunta si desea cerrar el
        /// programa y cancela el evento de cierre si el usuario selecciona "No".
        /// </summary>
        /// <param name="sender">El objeto que levantó el evento, en este caso, el formulario
        /// SalasPartida.</param>
        /// <param name="FormClosingEventArgs">Es un argumento de evento que se pasa al controlador de
        /// eventos para el evento FormClosing. Proporciona información sobre el evento y permite que el
        /// controlador de eventos cancele el cierre del formulario si es necesario.</param>
        /// <returns>
        /// Si el usuario selecciona "No" en el cuadro de mensaje, el controlador de eventos establece
        /// la propiedad Cancelar del objeto FormClosingEventArgs en verdadero y devuelve, lo que indica
        /// que se debe cancelar el cierre del formulario. Si el usuario selecciona "Sí" o cierra el
        /// cuadro de mensaje sin seleccionar una opción, el controlador de eventos no establece la
        /// propiedad Cancelar y simplemente regresa, permitiendo que se cierre el formulario.
        /// </returns>
        private void SalasPartida_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Desea Cerrar el Programa?", "Advertencia", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            else
            {
                Archivos.GuardarListasEnXML();
                Archivos.GuardarListasEnTXT();
                Archivos.GuardarListasEnJSON();
            }
        }

        #endregion Metodos
    }
}