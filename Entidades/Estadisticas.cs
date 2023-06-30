namespace Entidades
{
    public class Estadisticas
    {
        #region Atributos

        private int id;
        private string nombreUsuario;
        private int partidasGanadas;
        private int partidasJugadas;

        #endregion Atributos

        #region Constructores

        public Estadisticas()
        {
            id = 0;
        }

        public Estadisticas(int id, string nombreUsuario, int partidasGanadas, int partidasJugadas) : this()
        {
            this.id = id;
            this.nombreUsuario = nombreUsuario;
            this.partidasGanadas = partidasGanadas;
            this.partidasJugadas = partidasJugadas;
        }

        #endregion Constructores

        #region Propiedades

        public int Id { get => id; set => id = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public int PartidasGanadas { get => partidasGanadas; set => partidasGanadas = value; }
        public int PartidasJugadas { get => partidasJugadas; set => partidasJugadas = value; }

        #endregion Propiedades
    }
}