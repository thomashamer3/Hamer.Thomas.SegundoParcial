using Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Hamer.Thomas.SegundoParcial
{
    public partial class Juego : Form
    {
        #region Atributos

        public static List<Dados> Listadados = Dados.GetDados();
        private BaseDeDatos ado = new BaseDeDatos();
        private int contador = 0;
        private int contadorTurnos;
        private string creadorNombre;
        private Estadisticas estadistica = new Estadisticas();
        private bool estadoDePartida = false;
        private string estadoSala;
        private bool ganoJ1;
        private int idCreador;
        private int idSala;
        private int j1Puntos;
        private int j2Puntos;
        private bool poderCerrar = false;
        private int puntos = 0;
        private List<string> TachadosJ1 = new List<string>();
        private List<string> TachadosJ2 = new List<string>();
        private DateTime tiempo = new DateTime();
        private string tiempoDePartida;
        private bool tocoBoton = false;
        private int turnoJugador = 1;
        private string ultimoUsado;

        #endregion Atributos

        #region Constructor

        public Juego()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Propiedades

        public int ContadorTurnos { get => contadorTurnos; set => contadorTurnos = value; }
        public string CreadorNombre { get => creadorNombre; set => creadorNombre = value; }
        public string EstadoSala { get => estadoSala; set => estadoSala = value; }
        public int IdCreador { get => idCreador; set => idCreador = value; }
        public int IdSala { get => idSala; set => idSala = value; }
        public int J1Puntos { get => j1Puntos; set => j1Puntos = value; }
        public int J2Puntos { get => j2Puntos; set => j2Puntos = value; }
        public string TiempoDePartida { get => tiempoDePartida; set => tiempoDePartida = value; }

        #endregion Propiedades

        #region Metodos

        /// <summary>
        /// La Metodo ActivarPB habilita todos los cuadros de imagen en un programa C#.
        /// </summary>
        private void ActivarPB()
        {
            pictureBoxUno.Enabled = true;
            pictureBoxDos.Enabled = true;
            pictureBoxTres.Enabled = true;
            pictureBoxCuatro.Enabled = true;
            pictureBoxCinco.Enabled = true;
            pictureBoxSeis.Enabled = true;
            pictureBoxPoker.Enabled = true;
            pictureBoxGenerala.Enabled = true;
            pictureBoxLibre.Enabled = true;
        }

        /// <summary>
        /// Esta Metodo actualiza los puntos del jugador actual y cambia al turno del siguiente jugador
        /// en un juego de dados.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento (en este caso, el botón
        /// "btnConfirmar").</param>
        /// <param name="EventArgs">Un objeto que contiene los datos del evento. Proporciona información
        /// sobre el evento que ha ocurrido. En este caso, es el evento de clic de un botón.</param>
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            int ptsActualJ1;
            int ptsActualJ2;

            if (tocoBoton == true & turnoJugador != 8)
            {
                contadorTurnos--;
                lblTurnosRestantes.Text = contadorTurnos.ToString();

                if (turnoJugador == 1)
                {
                    ptsActualJ1 = Convert.ToInt32(lblPuntosJugador1.Text);
                    J1Puntos = ptsActualJ1 + puntos;
                    TachadosJ1.Add(ultimoUsado);
                }
                else
                {
                    ptsActualJ2 = Convert.ToInt32(lblPuntoJugador2.Text);
                    J2Puntos = ptsActualJ2 + puntos;
                    TachadosJ2.Add(ultimoUsado);
                }

                lblPuntosJugador1.Text = J1Puntos.ToString();
                lblPuntoJugador2.Text = J2Puntos.ToString();

                puntos = 0;
                tocoBoton = false;
                lblRestantes.Text = "Restantes: 3";
                RestaurarDados();
                RestaurarColores();
                ActivarPB();
                if (turnoJugador == 1)
                {
                    turnoJugador = 2;
                    lblTurnoJugador.Text = "Turno de jugador: 2";
                    RevisarTachados(TachadosJ2);
                }
                else
                {
                    turnoJugador = 1;
                    lblTurnoJugador.Text = "Turno de jugador: 1";
                    RevisarTachados(TachadosJ1);
                }
                if (contadorTurnos == 0)
                {
                    Ganador();
                }

                contador = 0;
                foreach (Label item in panelDeValores.Controls.OfType<Label>())
                {
                    item.Text = "0";
                }
            }
            else
            {
                MessageBox.Show("Seleccione algún valor.", "Error.");
            }
        }

        /// <summary>
        /// Esta Metodo guarda y sale de una sala de juegos, actualizando las estadísticas si el juego
        /// ha terminado.
        /// </summary>
        /// <param name="sender">El objeto que provocó el evento (en este caso, el botón en el que se
        /// hizo clic).</param>
        /// <param name="EventArgs">EventArgs es una clase en C# que proporciona datos para un evento.
        /// No contiene datos, pero se utiliza como clase base para las clases que proporcionan datos de
        /// eventos. En este fragmento de código específico, el parámetro EventArgs no se usa, pero la
        /// firma del controlador de eventos lo requiere.</param>
        private void btnGuardarSalir_Click(object sender, EventArgs e)
        {
            Salas obj = new Salas();
            obj.IDSala = IdSala;
            obj.PuntosJ1 = J1Puntos;
            obj.PuntosJ2 = J2Puntos;
            obj.Estado = EstadoSala;
            obj.TurnosRestantes1 = contadorTurnos;
            obj.TiempoDePartida1 = tiempo.ToString("H:mm:ss");
            obj.Creador = IdCreador;

            estadistica = ado.SelectById(IdCreador);

            if (EstadoSala == "Finalizada")
            {
                estadistica.PartidasJugadas++;
                if (ganoJ1)
                {
                    estadistica.PartidasGanadas++;
                }

                ado.GuardarEstadisticas(estadistica);
            }

            ado.GuardarYSalir(obj);
            Close();
        }

        /// <summary>
        /// La Metodo cierra el formulario actual cuando se hace clic en el botón "Salir".
        /// </summary>
        /// <param name="sender">El objeto que generó el evento, en este caso, el botón en el que se
        /// hizo clic (btnSalir).</param>
        /// <param name="EventArgs">EventArgs es una clase en C# que proporciona datos para un evento.
        /// No contiene datos, pero se utiliza como clase base para las clases que proporcionan datos de
        /// eventos. En este fragmento de código específico, EventArgs se usa como un parámetro para el
        /// método del controlador de eventos btnSalir_Click, que se llama cuando el</param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// La Metodo maneja el evento de clic de un botón para tirar los dados y actualizar el
        /// contador de tiradas restantes.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento (en este caso, el botón
        /// "btnTirar").</param>
        /// <param name="EventArgs">Un objeto que contiene datos de eventos, que proporciona información
        /// sobre el evento que ocurrió. En este caso, representa el evento de clic de un botón.</param>
        private void btnTirar_Click(object sender, EventArgs e)
        {
            contador++;
            if (contador <= 3)
            {
                TiradaDeDados(pictureBoxUno, 0);
                TiradaDeDados(pictureBoxDos, 1);
                TiradaDeDados(pictureBoxTres, 2);
                TiradaDeDados(pictureBoxCuatro, 3);
                TiradaDeDados(pictureBoxCinco, 4);
                if (contador == 1)
                {
                    lblRestantes.Text = "Restantes: 2";
                }
                else
                {
                    if (contador == 2)
                    {
                        lblRestantes.Text = "Restantes: 1";
                    }
                    else
                    {
                        lblRestantes.Text = "Restantes: 0";
                    }
                }
            }
            Valores();
            pictureBoxUno.Enabled = true;
            pictureBoxDos.Enabled = true;
            pictureBoxTres.Enabled = true;
            pictureBoxCuatro.Enabled = true;
            pictureBoxCinco.Enabled = true;
        }

        /// <summary>
        /// La Metodo "Cinco" cuenta el número de veces que aparece el valor 5 en una lista de tiradas
        /// de dados y devuelve el recuento total.
        /// </summary>
        /// <returns>
        /// El método devuelve un valor entero, que es la suma total de todas las tiradas de dados que
        /// dieron como resultado un valor de 5.
        /// </returns>
        private int Cinco()
        {
            int ContadorCinco = 0;

            for (int i = 0; i < 5; i++)
            {
                if (Listadados[i].ValorDado == 5)
                {
                    ContadorCinco = ContadorCinco + 5;
                }
            }

            lblCantidadCinco.Text = ContadorCinco.ToString();
            return ContadorCinco;
        }

        /// <summary>
        /// La Metodo cuenta el número de veces que aparece el valor 4 en una lista de tiradas de dados
        /// y devuelve el recuento total.
        /// </summary>
        /// <returns>
        /// El método devuelve un valor entero, que es la suma total de todas las tiradas de dados que
        /// dieron como resultado un valor de 4.
        /// </returns>
        private int Cuatro()
        {
            int ContadorCuatro = 0;

            for (int i = 0; i < 5; i++)
            {
                if (Listadados[i].ValorDado == 4)
                {
                    ContadorCuatro = ContadorCuatro + 4;
                }
            }

            lblCantidadCuatro.Text = ContadorCuatro.ToString();
            return ContadorCuatro;
        }

        /// <summary>
        /// La Metodo "Dos" cuenta el número de veces que aparece el valor 2 en una lista de tiradas de
        /// dados y devuelve el recuento total.
        /// </summary>
        /// <returns>
        /// El método devuelve un valor entero, que es el recuento total del número 2 en una lista de
        /// tiradas de dados.
        /// </returns>
        private int Dos()
        {
            int ContadorDos = 0;

            for (int i = 0; i < 5; i++)
            {
                if (Listadados[i].ValorDado == 2)
                {
                    ContadorDos = ContadorDos + 2;
                }
            }

            lblCantidadDos.Text = ContadorDos.ToString();
            return ContadorDos;
        }

        /// <summary>
        /// La Metodo comprueba si hay una secuencia de cinco valores de dados y devuelve una
        /// puntuación de 20 si la hay, o 0 si hay valores duplicados.
        /// </summary>
        /// <returns>
        /// El método devuelve un valor entero, que es la puntuación de una posible escalera en un juego
        /// de dados.
        /// </returns>
        private int Escalera()
        {
            int valor = 20;
            bool encontro;

            for (int i = 0; i < 5; i++)
            {
                encontro = false;
                for (int j = 0; j < 5; j++)
                {
                    if (Listadados[i].ValorDado == Listadados[j].ValorDado)
                    {
                        if (!(i == j))
                        {
                            encontro = true;
                        }
                    }
                }
                if (encontro)
                {
                    valor = 0;
                    break;
                }
            }

            lblCantidadEscalera.Text = valor.ToString();

            return valor;
        }

        /// <summary>
        /// Esta Metodo comprueba si un conjunto de cinco tiradas de dados contiene una combinación de
        /// casa completa y devuelve una puntuación de 35 si la contiene.
        /// </summary>
        /// <returns>
        /// El método devuelve un valor entero, que es la puntuación de una combinación completa en un
        /// juego de dados.
        /// </returns>
        private int Full()
        {
            int valor = 0;
            bool Dos = false;
            bool Tres = false;
            int contador2;
            int contador3;

            for (int i = 0; i < 5; i++)
            {
                contador2 = 1;
                for (int j = 0; j < 5; j++)
                {
                    if (Listadados[i].ValorDado == Listadados[j].ValorDado)
                    {
                        if (!(i == j))
                        {
                            contador2++;
                            if (contador2 == 2)
                            {
                                Dos = true;
                            }
                            else
                            {
                                if (contador2 > 2)
                                {
                                    Dos = false;
                                    break;
                                }
                            }
                        }
                    }
                }
                if (contador2 == 2)
                {
                    break;
                }
            }

            for (int i = 0; i < 5; i++)
            {
                contador3 = 1;
                for (int j = 0; j < 5; j++)
                {
                    if (Listadados[i].ValorDado == Listadados[j].ValorDado)
                    {
                        if (!(i == j))
                        {
                            contador3++;
                            if (contador3 == 3)
                            {
                                Tres = true;
                            }
                            else
                            {
                                if (contador3 > 3)
                                {
                                    Tres = false;
                                    break;
                                }
                            }
                        }
                    }
                }
                if (contador3 == 3)
                {
                    break;
                }
            }

            if (Tres == true && Dos == true)
            {
                valor = 35;
            }

            lblCantidadFull.Text = valor.ToString();

            return valor;
        }

        /// <summary>
        /// La Metodo determina el ganador de un juego y actualiza el estado del juego en consecuencia.
        /// </summary>
        private void Ganador()
        {
            EstadoSala = "Finalizada";
            if (J1Puntos > J2Puntos)
            {
                MessageBox.Show("El Ganador es el Jugador 1.");
                ganoJ1 = true; ;
            }
            else
            {
                if (J2Puntos > J1Puntos)
                {
                    MessageBox.Show("El Ganador es el Jugador 2.");
                    ganoJ1 = false;
                }
                else
                {
                    MessageBox.Show("EMPATE!!!!");
                    ganoJ1 = false;
                }
            }

            btnConfirmar.Enabled = false;
            estadoDePartida = true;

            // Mandar a la base de datos de estadísticas.
        }

        /// <summary>
        /// La Metodo verifica si los cinco dados tienen el mismo valor y devuelve 50 si es verdadero,
        /// de lo contrario devuelve 0.
        /// </summary>
        /// <returns>
        /// El método devuelve un valor entero, que es la puntuación de una Generala (una tirada en la
        /// que los cinco dados muestran el mismo valor).
        /// </returns>
        private int Generala()
        {
            int generala = 0;

            for (int i = 0; i < 5; i++)
            {
                if (Listadados[0].ValorDado == Listadados[i].ValorDado)
                {
                    generala = 50;
                }
                else
                {
                    generala = 0;
                    break;
                }
            }

            lblCantidadGenerala.Text = generala.ToString();
            return generala;
        }

        /// <summary>
        /// Esta Metodo solicita al usuario que confirme el cierre de la aplicación y guarda los datos
        /// antes de cerrar si se confirma.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento, en este caso, el formulario
        /// Juego.</param>
        /// <param name="FormClosingEventArgs">Este es un argumento de evento que se pasa al controlador
        /// de eventos FormClosing. Contiene información sobre el evento, como si el usuario o el
        /// sistema están cerrando el formulario, y permite que el controlador de eventos cancele el
        /// cierre del formulario si es necesario.</param>
        private void Juego_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!poderCerrar)
            {
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas cerrar la aplicación?",
                    "Confirmar cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    Archivos.GuardarListasEnXML();
                    Archivos.GuardarListasEnTXT();
                    Archivos.GuardarListasEnJSON();
                }
            }
        }

        /// <summary>
        /// La Metodo calcula la suma de los valores de los primeros cinco elementos de una lista y
        /// devuelve el resultado.
        /// </summary>
        /// <returns>
        /// El método está devolviendo un valor entero, que es la suma de los valores de los primeros 5
        /// elementos en la matriz Listadados.
        /// </returns>
        private int Libre()
        {
            int acumulador = 0;

            for (int i = 0; i < 5; i++)
            {
                acumulador = acumulador + Listadados[i].ValorDado;
            }

            lblCantidadLibre.Text = acumulador.ToString();

            return acumulador;
        }

        /// <summary>
        /// Esta Metodo cambia el estado de un elemento de datos y actualiza la visibilidad de una
        /// etiqueta en consecuencia cuando se hace clic en un cuadro de imagen específico.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento, en este caso, el
        /// pictureBoxCautroBloqueado.</param>
        /// <param name="EventArgs">EventArgs es una clase en C# que proporciona datos para un evento.
        /// No contiene datos, pero se utiliza como clase base para las clases que proporcionan datos de
        /// eventos. En este caso, se utiliza como parámetro para el método manejador de eventos
        /// pictureBoxCautroBloqueado_Click, que es</param>
        private void pictureBoxCautroBloqueado_Click(object sender, EventArgs e)
        {
            if (Listadados[3].Estado == false)
            {
                Listadados[3].Estado = true;
                lblBloqueadoDadoCuatro.Visible = false;
            }
            else
            {
                Listadados[3].Estado = false;
                lblBloqueadoDadoCuatro.Visible = true;
            }
        }

        /// <summary>
        /// Esta Metodo maneja el evento de clic para un cuadro de imagen y realiza varias acciones
        /// relacionadas con la lógica del juego.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento, en este caso, el control
        /// pictureBoxCinco.</param>
        /// <param name="EventArgs">EventArgs es una clase en C# que proporciona datos para un evento.
        /// No contiene datos, pero se utiliza como clase base para las clases que proporcionan datos de
        /// eventos. En este caso, se utiliza como parámetro para el método del controlador de eventos
        /// pictureBoxCinco_Click, que se llama cuando el</param>
        private void pictureBoxCinco_Click(object sender, EventArgs e)
        {
            RestaurarColores();
            TacharCuandoClickPB(turnoJugador);
            tocoBoton = true;
            puntos = Cinco();
            ultimoUsado = "Cinco";
            lblCantidadCinco.ForeColor = Color.Yellow;
        }

        /// <summary>
        /// Esta Metodo cambia el estado de un elemento de datos y oculta/muestra una etiqueta en
        /// consecuencia cuando se hace clic en un cuadro de imagen determinado.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento, en este caso, el control
        /// pictureBoxCincoBloqueado.</param>
        /// <param name="EventArgs">EventArgs es una clase en C# que proporciona datos para un evento.
        /// No contiene datos, pero se utiliza como clase base para las clases que proporcionan datos de
        /// eventos. En este caso, se utiliza como parámetro para el método manejador de eventos
        /// pictureBoxCincoBloqueado_Click, que es</param>
        private void pictureBoxCincoBloqueado_Click(object sender, EventArgs e)
        {
            if (Listadados[4].Estado == false)
            {
                Listadados[4].Estado = true;
                lblBloqueadoDadoCinco.Visible = false;
            }
            else
            {
                Listadados[4].Estado = false;
                lblBloqueadoDadoCinco.Visible = true;
            }
        }

        /// <summary>
        /// La Metodo maneja el evento de clic para un cuadro de imagen, actualiza las variables del
        /// juego y cambia el color de una etiqueta.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento, en este caso, el control
        /// pictureBoxCuatro.</param>
        /// <param name="EventArgs">EventArgs es una clase en C# que proporciona datos para un evento.
        /// No contiene datos, pero se utiliza como clase base para las clases que proporcionan datos de
        /// eventos. En este caso, se utiliza como parámetro para el método manejador de eventos
        /// pictureBoxCuatro_Click, que se llama cuando el usuario</param>
        private void pictureBoxCuatro_Click(object sender, EventArgs e)
        {
            RestaurarColores();
            TacharCuandoClickPB(turnoJugador);
            tocoBoton = true;
            puntos = Cuatro();
            ultimoUsado = "Cuatro";
            lblCantidadCuatro.ForeColor = Color.Yellow;
        }

        /// <summary>
        /// Esta Metodo maneja el evento de clic para un cuadro de imagen y realiza varias acciones
        /// relacionadas con un juego, como restaurar colores, marcar un cuadrado, calcular puntos y
        /// actualizar el color del texto de una etiqueta.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento, en este caso, el control
        /// pictureBoxDos.</param>
        /// <param name="EventArgs">EventArgs es una clase en C# que proporciona datos para un evento.
        /// No contiene datos, pero se utiliza como clase base para las clases que proporcionan datos de
        /// eventos. En este caso, se utiliza como parámetro para el método del controlador de eventos
        /// pictureBoxDos_Click, que se llama cuando el usuario hace clic</param>
        private void pictureBoxDos_Click(object sender, EventArgs e)
        {
            RestaurarColores();
            TacharCuandoClickPB(turnoJugador);
            tocoBoton = true;
            puntos = Dos();
            ultimoUsado = "Dos";
            lblCantidadDos.ForeColor = Color.Yellow;
        }

        /// <summary>
        /// Esta Metodo cambia el estado de un elemento de datos y actualiza la visibilidad de una
        /// etiqueta en consecuencia cuando se hace clic en un cuadro de imagen.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento, en este caso, el control
        /// pictureBoxDosBloqueado.</param>
        /// <param name="EventArgs">EventArgs es una clase en C# que proporciona datos para un evento.
        /// No contiene datos, pero se utiliza como clase base para las clases que proporcionan datos de
        /// eventos. En este caso, se utiliza como parámetro para el método del controlador de eventos
        /// pictureBoxDosBloqueado_Click, que se activa cuando</param>
        private void pictureBoxDosBloqueado_Click(object sender, EventArgs e)
        {
            if (Listadados[1].Estado == false)
            {
                Listadados[1].Estado = true;
                lblBloqueadoDadoDos.Visible = false;
            }
            else
            {
                Listadados[1].Estado = false;
                lblBloqueadoDadoDos.Visible = true;
            }
        }

        /// <summary>
        /// Esta Metodo maneja el evento de clic de un cuadro de imagen y realiza varias acciones
        /// relacionadas con un juego, incluido el cálculo de puntos y el cambio de colores de las
        /// etiquetas.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento, en este caso, el control
        /// pictureBoxEscalera.</param>
        /// <param name="EventArgs">EventArgs es una clase en C# que proporciona datos para un evento.
        /// No contiene datos, pero se utiliza como clase base para las clases que proporcionan datos de
        /// eventos. Se usa comúnmente como un parámetro para los controladores de eventos.</param>
        private void pictureBoxEscalera_Click(object sender, EventArgs e)
        {
            RestaurarColores();
            TacharCuandoClickPB(turnoJugador);
            tocoBoton = true;
            puntos = Escalera();
            ultimoUsado = "Escalera";
            lblCantidadEscalera.ForeColor = Color.Yellow;
        }

        /// <summary>
        /// Esta Metodo maneja el evento de clic de un cuadro de imagen y realiza varias acciones
        /// relacionadas con un juego, como restaurar colores, marcar un botón como presionado, calcular
        /// puntos y actualizar el color de una etiqueta.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento, en este caso, el cuadro de imagen en el
        /// que se hizo clic.</param>
        /// <param name="EventArgs">EventArgs es una clase en C# que proporciona datos para un evento.
        /// No contiene datos, pero se utiliza como clase base para las clases que proporcionan datos de
        /// eventos. En este caso, se usa como un parámetro para el método del controlador de eventos
        /// pictureBoxFull_Click, que se llama cuando el usuario hace clic</param>
        private void pictureBoxFull_Click(object sender, EventArgs e)
        {
            RestaurarColores();
            TacharCuandoClickPB(turnoJugador);
            tocoBoton = true;
            puntos = Full();
            ultimoUsado = "Full";
            lblCantidadFull.ForeColor = Color.Yellow;
        }

        /// <summary>
        /// La Metodo maneja el evento de clic de un cuadro de imagen y realiza acciones relacionadas
        /// con un juego de Generala.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento, en este caso, el control
        /// pictureBoxGenerala.</param>
        /// <param name="EventArgs">EventArgs es una clase en C# que proporciona datos para un evento.
        /// No contiene datos, pero se utiliza como clase base para las clases que proporcionan datos de
        /// eventos. En este caso, se utiliza como parámetro para el método del controlador de eventos
        /// pictureBoxGenerala_Click, que se llama cuando el usuario</param>
        private void pictureBoxGenerala_Click(object sender, EventArgs e)
        {
            RestaurarColores();
            TacharCuandoClickPB(turnoJugador);
            tocoBoton = true;
            puntos = Generala();
            ultimoUsado = "Generala";
            lblCantidadGenerala.ForeColor = Color.Yellow;
        }

        /// <summary>
        /// Esta Metodo maneja el evento de clic de un cuadro de imagen y realiza varias acciones
        /// relacionadas con un juego, como restaurar colores, marcar un cuadrado, calcular puntos y
        /// actualizar etiquetas.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento, en este caso, el control
        /// pictureBoxLibre.</param>
        /// <param name="EventArgs">EventArgs es una clase en C# que proporciona datos para un evento.
        /// No contiene datos, pero se usa como clase base para las clases que proporcionan datos de
        /// eventos. En este caso, se utiliza como parámetro para el método del controlador de eventos
        /// pictureBoxLibre_Click, que se llama cuando el usuario</param>
        private void pictureBoxLibre_Click(object sender, EventArgs e)
        {
            RestaurarColores();
            TacharCuandoClickPB(turnoJugador);
            tocoBoton = true;
            puntos = Libre();
            ultimoUsado = "Libre";
            lblCantidadLibre.ForeColor = Color.Yellow;
        }

        /// <summary>
        /// La Metodo maneja el evento de clic de un cuadro de imagen relacionado con un juego de
        /// póquer y actualiza el estado del juego en consecuencia.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento, en este caso, el control
        /// pictureBoxPoker.</param>
        /// <param name="EventArgs">EventArgs es una clase en C# que proporciona datos para un evento.
        /// No contiene datos, pero se utiliza como clase base para las clases que proporcionan datos de
        /// eventos. En este caso, se usa como un parámetro para el método del controlador de eventos
        /// pictureBoxPoker_Click, que se llama cuando el usuario</param>
        private void pictureBoxPoker_Click(object sender, EventArgs e)
        {
            RestaurarColores();
            TacharCuandoClickPB(turnoJugador);
            tocoBoton = true;
            puntos = Poker();
            ultimoUsado = "Poker";
            lblCantidadPoker.ForeColor = Color.Yellow;
        }

        /// <summary>
        /// Esta Metodo maneja el evento de clic para un cuadro de imagen y realiza varias acciones
        /// relacionadas con un juego, como restaurar colores, marcar un botón como presionado, calcular
        /// puntos y actualizar el color de una etiqueta.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento, en este caso, el control
        /// pictureBoxSeis.</param>
        /// <param name="EventArgs">EventArgs es una clase en C# que proporciona datos para un evento.
        /// No contiene datos, pero se utiliza como clase base para las clases que proporcionan datos de
        /// eventos. En este caso, se usa como un parámetro para el método del controlador de eventos
        /// pictureBoxSeis_Click, que se llama cuando el usuario</param>
        private void pictureBoxSeis_Click(object sender, EventArgs e)
        {
            RestaurarColores();
            TacharCuandoClickPB(turnoJugador);
            tocoBoton = true;
            puntos = Seis();
            ultimoUsado = "Seis";
            lblCantidadSeis.ForeColor = Color.Yellow;
        }

        /// <summary>
        /// La Metodo se activa cuando se hace clic en un cuadro de imagen y realiza varias acciones
        /// relacionadas con un juego, como restaurar colores, marcar un cuadrado, actualizar puntos y
        /// cambiar el color de una etiqueta.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento, en este caso, el control
        /// pictureBoxTres.</param>
        /// <param name="EventArgs">EventArgs es una clase en C# que proporciona datos para un evento.
        /// No contiene datos, pero se utiliza como clase base para las clases que proporcionan datos de
        /// eventos. En este caso, se utiliza como parámetro para el método del controlador de eventos
        /// pictureBoxTres_Click, que se llama cuando el usuario</param>
        private void pictureBoxTres_Click(object sender, EventArgs e)
        {
            RestaurarColores();
            TacharCuandoClickPB(turnoJugador);
            tocoBoton = true;
            puntos = Tres();
            ultimoUsado = "Tres";
            lblCantidadTres.ForeColor = Color.Yellow;
        }

        /// <summary>
        /// Esta Metodo cambia el estado de un elemento de datos y actualiza la visibilidad de una
        /// etiqueta en consecuencia cuando se hace clic en un cuadro de imagen específico.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento, en este caso, el control
        /// pictureBoxTresBloqueado.</param>
        /// <param name="EventArgs">EventArgs es una clase en C# que proporciona datos para un evento.
        /// No contiene datos, pero se utiliza como clase base para las clases que proporcionan datos de
        /// eventos. En este caso, se utiliza como parámetro para el método del controlador de eventos
        /// pictureBoxTresBloqueado_Click, que se activa</param>
        private void pictureBoxTresBloqueado_Click(object sender, EventArgs e)
        {
            if (Listadados[2].Estado == false)
            {
                Listadados[2].Estado = true;
                lblBloqueadoDadoTres.Visible = false;
            }
            else
            {
                Listadados[2].Estado = false;
                lblBloqueadoDadoTres.Visible = true;
            }
        }

        /// <summary>
        /// La Metodo maneja el evento de clic de un cuadro de imagen y realiza varias acciones
        /// relacionadas con un juego, como restaurar colores, marcar un botón como presionado, calcular
        /// puntos y actualizar el color de una etiqueta.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento, en este caso, el control
        /// pictureBoxUno.</param>
        /// <param name="EventArgs">EventArgs es una clase en C# que proporciona datos para un evento.
        /// No contiene datos, pero se utiliza como clase base para las clases que proporcionan datos de
        /// eventos. En este caso, se usa como un parámetro para el método del controlador de eventos
        /// pictureBoxUno_Click, que se llama cuando el usuario hace clic</param>
        private void pictureBoxUno_Click(object sender, EventArgs e)
        {
            RestaurarColores();
            TacharCuandoClickPB(turnoJugador);
            tocoBoton = true;
            puntos = Uno();
            ultimoUsado = "Uno";
            lblCantidadUno.ForeColor = Color.Yellow;
        }

        /// <summary>
        /// Esta Metodo cambia el estado de un objeto de datos y oculta/muestra una etiqueta en
        /// consecuencia cuando se hace clic en un cuadro de imagen.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento, en este caso, el control
        /// pictureBoxUnoBloqueado.</param>
        /// <param name="EventArgs">EventArgs es una clase en C# que proporciona datos para un evento.
        /// No contiene datos, pero se utiliza como clase base para las clases que proporcionan datos de
        /// eventos. En este caso, se utiliza como parámetro para el método del controlador de eventos
        /// pictureBoxUnoBloqueado_Click, que se activa cuando</param>
        private void pictureBoxUnoBloqueado_Click(object sender, EventArgs e)
        {
            if (Listadados[0].Estado == false)
            {
                Listadados[0].Estado = true;
                lblBloqueadoDadoUno.Visible = false;
            }
            else
            {
                Listadados[0].Estado = false;
                lblBloqueadoDadoUno.Visible = true;
            }
        }

        /// <summary>
        /// La Metodo comprueba si hay un póquer (cuatro del mismo tipo) en una lista de valores de
        /// dados y devuelve una puntuación de 40 si lo encuentra.
        /// </summary>
        /// <returns>
        /// El método devuelve un valor entero, que es la puntuación de una mano de póquer.
        /// </returns>
        private int Poker()
        {
            int valor = 0;
            int contador;

            for (int i = 0; i < 5; i++)
            {
                contador = 1;
                for (int j = 0; j < 5; j++)
                {
                    if (Listadados[i].ValorDado == Listadados[j].ValorDado)
                    {
                        if (!(i == j))
                        {
                            contador++;
                            if (contador == 4)
                            {
                                valor = 40;
                                break;
                            }
                        }
                    }
                }
            }

            lblCantidadPoker.Text = valor.ToString();

            return valor;
        }

        /// <summary>
        /// La Metodo RestaurarColores restaura el color de todas las etiquetas de un panel a blanco.
        /// </summary>
        private void RestaurarColores()
        {
            foreach (Label item in panelDeValores.Controls.OfType<Label>())
            {
                item.ForeColor = Color.White;
            }
        }

        /// <summary>
        /// La Metodo restablece el estado y los valores de cinco imágenes y etiquetas de dados.
        /// </summary>
        private void RestaurarDados()
        {
            pictureBoxUno.Enabled = false;
            pictureBoxDos.Enabled = false;
            pictureBoxTres.Enabled = false;
            pictureBoxCuatro.Enabled = false;
            pictureBoxCinco.Enabled = false;
            pictureBoxUno.Image = null;
            pictureBoxDos.Image = null;
            pictureBoxTres.Image = null;
            pictureBoxCuatro.Image = null;
            pictureBoxCinco.Image = null;
            lblBloqueadoDadoUno.Visible = false;
            lblBloqueadoDadoDos.Visible = false;
            lblBloqueadoDadoTres.Visible = false;
            lblBloqueadoDadoCuatro.Visible = false;
            lblBloqueadoDadoCinco.Visible = false;
            for (int i = 0; i < 5; i++)
            {
                Listadados[i].Estado = true;
                Listadados[i].ValorDado = 0;
            }
            Listadados[4].ValorDado = -1;
            Listadados[4].ValorDado = -2;
        }

        /// <summary>
        /// Esta Metodo desactiva ciertos cuadros de imagen y cambia el color de ciertas etiquetas
        /// según los elementos de una lista.
        /// </summary>
        /// <param name="listaTachado">Una lista de cadenas que contienen los nombres de los elementos
        /// que deben deshabilitarse y cambiar el color del texto de sus etiquetas correspondientes a
        /// rojo.</param>
        private void RevisarTachados(List<string> listaTachado)
        {
            foreach (string item in listaTachado)
            {
                switch (item)
                {
                    case "Uno":
                        pictureBoxUno.Enabled = false;
                        lblCantidadUno.ForeColor = Color.Red;
                        break;

                    case "Dos":
                        pictureBoxDos.Enabled = false;
                        lblCantidadDos.ForeColor = Color.Red;
                        break;

                    case "Tres":
                        pictureBoxTres.Enabled = false;
                        lblCantidadTres.ForeColor = Color.Red;
                        break;

                    case "Cuatro":
                        pictureBoxCuatro.Enabled = false;
                        lblCantidadCuatro.ForeColor = Color.Red;
                        break;

                    case "Cinco":
                        pictureBoxCinco.Enabled = false;
                        lblCantidadCinco.ForeColor = Color.Red;
                        break;

                    case "Seis":
                        pictureBoxSeis.Enabled = false;
                        lblCantidadSeis.ForeColor = Color.Red;
                        break;

                    case "Libre":
                        pictureBoxLibre.Enabled = false;
                        lblCantidadLibre.ForeColor = Color.Red;
                        break;

                    case "Generala":
                        pictureBoxGenerala.Enabled = false;
                        lblCantidadGenerala.ForeColor = Color.Red;
                        break;

                    case "Poker":
                        pictureBoxPoker.Enabled = false;
                        lblCantidadPoker.ForeColor = Color.Red;
                        break;

                    case "Full":
                        pictureBoxFull.Enabled = false;
                        lblCantidadFull.ForeColor = Color.Red;
                        break;

                    case "Escalera":
                        pictureBoxEscalera.Enabled = false;
                        lblCantidadEscalera.ForeColor = Color.Red;
                        break;
                }
            }
        }

        /// <summary>
        /// La Metodo "Seis" cuenta el número de veces que aparece el valor 6 en una lista de tiradas
        /// de dados y devuelve el recuento total.
        /// </summary>
        /// <returns>
        /// El método devuelve un valor entero, que es la suma total de todas las tiradas de dados que
        /// dieron como resultado un valor de 6.
        /// </returns>
        private int Seis()
        {
            int ContadorSeis = 0;

            for (int i = 0; i < 5; i++)
            {
                if (Listadados[i].ValorDado == 6)
                {
                    ContadorSeis = ContadorSeis + 6;
                }
            }

            lblCantidadSeis.Text = ContadorSeis.ToString();
            return ContadorSeis;
        }

        /// <summary>
        /// Esta Metodo verifica los elementos tachados según el turno del jugador.
        /// </summary>
        /// <param name="jugadorTurno">una variable entera que representa el turno del jugador actual
        /// (ya sea 1 o 2).</param>
        private void TacharCuandoClickPB(int jugadorTurno)
        {
            if (jugadorTurno == 1)
            {
                RevisarTachados(TachadosJ1);
            }
            else
            {
                RevisarTachados(TachadosJ2);
            }
        }

        /// <summary>
        /// Esta Metodo lanza un dado y muestra la imagen correspondiente en un cuadro de imagen.
        /// </summary>
        /// <param name="PictureBox">Un control en Windows Forms que muestra una imagen.</param>
        /// <param name="index">El parámetro índice es un número entero que representa el índice de los
        /// dados en la lista de Listadados que se está tirando.</param>
        private void TiradaDeDados(PictureBox dado, int index)
        {
            if (Listadados[index].Estado == true)
            {
                Random rnd = new Random();
                int tirada = rnd.Next(1, 7);
                Listadados[index].ValorDado = tirada;

                switch (tirada)
                {
                    case 1:
                        dado.Image = Image.FromFile("dado1.png");
                        break;

                    case 2:
                        dado.Image = Image.FromFile("dado2.png");
                        break;

                    case 3:
                        dado.Image = Image.FromFile("dado3.png");
                        break;

                    case 4:
                        dado.Image = Image.FromFile("dado4.png");
                        break;

                    case 5:
                        dado.Image = Image.FromFile("dado5.png");
                        break;

                    case 6:
                        dado.Image = Image.FromFile("dado6.png");
                        break;
                }
            }
        }

        /// <summary>
        /// La Metodo cuenta el número de veces que aparece el valor 3 en una lista de tiradas de dados
        /// y devuelve el recuento total.
        /// </summary>
        /// <returns>
        /// El método devuelve un valor entero, que es la suma total de todas las tiradas de dados que
        /// dieron como resultado un valor de 3.
        /// </returns>
        private int Tres()
        {
            int ContadorTres = 0;

            for (int i = 0; i < 5; i++)
            {
                if (Listadados[i].ValorDado == 3)
                {
                    ContadorTres = ContadorTres + 3;
                }
            }

            lblCantidadTres.Text = ContadorTres.ToString();
            return ContadorTres;
        }

        /// <summary>
        /// La Metodo cuenta el número de dados con valor 1 en una lista de dados.
        /// </summary>
        /// <returns>
        /// El método devuelve un valor entero, que es el número de veces que aparece el valor 1 en la
        /// lista de tiradas de dados.
        /// </returns>
        private int Uno()
        {
            int ContadorUno = 0;

            for (int i = 0; i < 5; i++)
            {
                if (Listadados[i].ValorDado == 1)
                {
                    ContadorUno++;
                }
            }

            lblCantidadUno.Text = ContadorUno.ToString();
            return ContadorUno;
        }

        /// <summary>
        /// La Metodo "Valores" llama a varias otras Metodoones relacionadas con un juego de dados para
        /// calcular y almacenar puntajes para diferentes categorías.
        /// </summary>
        private void Valores()
        {
            Uno();
            Dos();
            Tres();
            Cuatro();
            Cinco();
            Seis();
            Libre();
            Generala();
            Poker();
            Full();
            Escalera();
        }

        #endregion Metodos
    }
}