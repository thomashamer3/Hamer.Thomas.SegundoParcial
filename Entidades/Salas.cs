namespace Entidades
{
    public class Salas
    {
        private int creador;
        private string creadorUsername;
        private string estado;
        private int IDSala;
        private int puntosJ1;
        private int puntosJ2;
        private string TiempoDePartida;
        private int TurnosRestantes;

        public Salas()
        {
            this.estado = "En partida";
            this.puntosJ1 = 0;
            this.puntosJ2 = 0;
            this.TiempoDePartida = "0:00:00";
            this.TurnosRestantes = 8;
        }

        public Salas(int creador, string estado, int puntosJ1, int puntosJ2, int turnosRestantes, string tiempodePartida, int IDSala) : this()
        {
            this.creador = creador;
            this.estado = estado;
            this.puntosJ1 = puntosJ1;
            this.puntosJ2 = puntosJ2;
            this.TurnosRestantes = turnosRestantes;
            this.TiempoDePartida = tiempodePartida;
            this.IDSala = IDSala;
        }

        public int Creador { get => creador; set => creador = value; }
        public string CreadorUsername { get => creadorUsername; set => creadorUsername = value; }
        public string Estado { get => estado; set => estado = value; }
        public int IDSala1 { get => IDSala; set => IDSala = value; }
        public int PuntosJ1 { get => puntosJ1; set => puntosJ1 = value; }
        public int PuntosJ2 { get => puntosJ2; set => puntosJ2 = value; }
        public string TiempoDePartida1 { get => TiempoDePartida; set => TiempoDePartida = value; }
        public int TurnosRestantes1 { get => TurnosRestantes; set => TurnosRestantes = value; }
    }
}