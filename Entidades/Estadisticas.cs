using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    public class Estadisticas : ISelecionar<Estadisticas>
    {
        #region Atributos

        private static string cadenaConexion;
        private SqlCommand comando;
        private SqlConnection conexion;
        private int id;
        private SqlDataReader lector;
        private string nombreUsuario;
        private int partidasGanadas;
        private int partidasJugadas;

        #endregion Atributos

        #region Constructores

        static Estadisticas()
        {
            Estadisticas.cadenaConexion = @"Data source=.;initial catalog=Generala_Segundo_Parcial;integrated security=true";
        }

        public Estadisticas()
        {
            id = 0;
            nombreUsuario = string.Empty;
            partidasGanadas = 0;
            partidasJugadas = 0;
            this.conexion = new SqlConnection(Estadisticas.cadenaConexion);
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

        #region Metodos

        /// <summary>
        /// Este Metodo selecciona y devuelve una lista de estadísticas de los usuarios que han jugado
        /// y ganado juegos.
        /// </summary>
        /// <returns>
        /// Una lista de objetos Estadísticas.
        /// </returns>
        public List<Estadisticas> Selecionar()
        {
            List<Estadisticas> lista = new List<Estadisticas>();

            try
            {
                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "SELECT b.nombreUsuarioS,a.PartidasJugadas,a.PartidasGanadas,b.id FROM Estadistica a left join Usuarios b on b.id=a.IdUsuario";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Estadisticas item = new Estadisticas();

                    item.NombreUsuario = lector[0].ToString();
                    item.PartidasJugadas = lector.GetInt32(1);
                    item.PartidasGanadas = lector.GetInt32(2);
                    item.Id = lector.GetInt32(3);

                    lista.Add(item);
                }

                lector.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return lista;
        }

        #endregion Metodos
    }
}