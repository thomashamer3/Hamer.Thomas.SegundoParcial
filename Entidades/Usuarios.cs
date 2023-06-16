using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    public class Usuarios
    {
        #region Atributos

        private static string cadenaConexion;
        private string clave;
        private SqlCommand comando;
        private SqlConnection conexion;
        private SqlDataReader lector;
        private string nombreUsuario;

        #endregion Atributos

        #region Constructores

        static Usuarios()
        {
            Usuarios.cadenaConexion = @"Data source=.;initial catalog=Generala_Segundo_Parcial;integrated security=true";
        }

        public Usuarios()
        {
            this.nombreUsuario = string.Empty;
            this.clave = string.Empty;
            this.conexion = new SqlConnection(Usuarios.cadenaConexion);
        }

        public Usuarios(string nombreUsuario, string clave) : this()
        {
            this.nombreUsuario = nombreUsuario;
            this.clave = clave;
        }

        #endregion Constructores

        #region Propiedades

        public string Clave { get => clave; set => clave = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }

        #endregion Propiedades

        #region Metodos

        /// <summary>
        /// Este Metodo selecciona todos los usuarios de una base de datos y los devuelve como una
        /// lista de objetos Usuarios.
        /// </summary>
        /// <returns>
        /// Una lista de objetos de tipo "Usuarios".
        /// </returns>
        public List<Usuarios> Selecionar()
        {
            List<Usuarios> lista = new List<Usuarios>();

            try
            {
                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "SELECT * FROM Usuarios";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Usuarios item = new Usuarios();

                    item.NombreUsuario = lector[0].ToString();
                    item.Clave = lector[1].ToString();

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