using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    public class AdoEstadisticas : ISelecionar<Estadisticas>
    {
        #region Atributos

        private static string cadenaConexion;
        private SqlCommand comando;
        private SqlConnection conexion;
        private SqlDataReader lector;

        #endregion Atributos

        #region Constructores

        static AdoEstadisticas()
        {
            AdoEstadisticas.cadenaConexion = @"Data source=.;initial catalog=Generala_Segundo_Parcial;integrated security=true";
        }

        public AdoEstadisticas()
        {
            this.conexion = new SqlConnection(AdoEstadisticas.cadenaConexion);
        }

        #endregion Constructores

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
                this.comando.CommandText = "SELECT b.nombreUsuario,a.PartidasJugadas,a.PartidasGanadas,b.id FROM Estadistica a left join Usuarios b on b.id=a.IdUsuario";
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