using System.Collections.Generic;

namespace Entidades
{
    public class Dados
    {
        private bool estado;
        private int valorDado;

        public Dados()
        {
            this.valorDado = 0;
            this.estado = true;
        }

        public Dados(int valorDado, bool estado) : this()
        {
            this.valorDado = valorDado;
            this.estado = estado;
        }

        public bool Estado { get => estado; set => estado = value; }
        public int ValorDado { get => valorDado; set => valorDado = value; }

        /// <summary>
        /// Esta función devuelve una lista de cinco objetos Dados con valores iniciales de 0 y un valor
        /// booleano de verdadero.
        /// </summary>
        /// <returns>
        /// El método `GetDados` devuelve una `Lista` de objetos `Dados`.
        /// </returns>
        public static List<Dados> GetDados()
        {
            List<Dados> listaDados = new List<Dados>();

            Dados primerDado = new Dados(0, true);
            Dados segundoDado = new Dados(0, true);
            Dados tercerDado = new Dados(0, true);
            Dados cuartoDado = new Dados(-2, true);
            Dados quintoDado = new Dados(-1, true);

            listaDados.Add(primerDado);
            listaDados.Add(segundoDado);
            listaDados.Add(tercerDado);
            listaDados.Add(cuartoDado);
            listaDados.Add(quintoDado);

            return listaDados;
        }
    }
}