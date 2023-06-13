using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    public class BaseDeDatos
    {
        private static string cadenaConexion;
        private SqlCommand comando;
        private SqlConnection conexion;
        private SqlDataReader lector;

        static BaseDeDatos()
        {
            BaseDeDatos.cadenaConexion = @"Data source=.;initial catalog=Generala_Segundo_Parcial;integrated security=true";
        }

        public BaseDeDatos()
        {
            this.conexion = new SqlConnection(BaseDeDatos.cadenaConexion);
        }

        /// <summary>
        /// Esta función agrega un nuevo usuario a una base de datos si el usuario aún no existe.
        /// </summary>
        /// <param name="Usuarios">Una clase que representa a un usuario con propiedades como
        /// NombreUsuario (nombre de usuario) y Clave (contraseña).</param>
        /// <returns>
        /// Un valor booleano que indica si los datos se agregaron correctamente o no.
        /// </returns>
        public bool AgregarDato(Usuarios usuario)
        {
            bool rta = true;

            try
            {
                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = $"SELECT * FROM Usuarios WHERE nombreUsuario='{usuario.NombreUsuario}'";
                this.comando.Connection = this.conexion;

                this.conexion.Open();
                this.lector = this.comando.ExecuteReader();

                if (!this.lector.Read())
                {
                    this.lector.Close();

                    string SQL = "INSERT INTO Usuarios (nombreUsuario, contraseña) VALUES(";
                    SQL = SQL + "'" + usuario.NombreUsuario + "','" + usuario.Clave + "')";

                    this.comando.CommandText = SQL;

                    int filasAfectadas = this.comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        rta = true;
                    }
                }

                lector.Close();
            }
            catch (Exception e)
            {
                rta = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return rta;
        }

        /// <summary>
        /// Esta función agrega datos a una tabla de base de datos para una sala de juegos.
        /// </summary>
        /// <param name="Salas">Una clase que representa una sala de juegos con propiedades como Creador
        /// (ID del creador), Estado (estado de la sala), PuntosJ1 (puntos del jugador 1), PuntosJ2
        /// (puntos del jugador 2), TurnosRestantes1 (turnos restantes) y TiempoDePartida1</param>
        /// <returns>
        /// Un valor booleano que indica si los datos se agregaron con éxito a la base de datos o no.
        /// </returns>
        public bool AgregarDatoSala(Salas sala)
        {
            bool rta = true;

            try
            {
                string sql = "INSERT INTO Salas (CreadorID,EstadoSala,PuntosJ1,PuntosJ2,TurnosRestantes,TiempoDePartida) VALUES(";
                sql = sql + "'" + sala.Creador + "','" + sala.Estado + "'," + sala.PuntosJ1.ToString() + "," + sala.PuntosJ2.ToString() + "," + sala.TurnosRestantes1 +
                    ",'" + sala.TiempoDePartida1 + "')";

                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sql;
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    rta = false;
                }
            }
            catch (Exception e)
            {
                rta = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return rta;
        }

        /// <summary>
        /// Esta función agrega una nueva fila a una tabla de base de datos llamada "Estadistica" con
        /// los valores proporcionados para "PartidasJugadas" y "PartidasGanadas".
        /// </summary>
        /// <param name="Estadisticas">Una clase que representa estadísticas, con propiedades para
        /// PartidasJugadas (número de juegos jugados), PartidasGanadas (número de juegos ganados) y
        /// PorcentajeGanadas (porcentaje de juegos ganados).</param>
        /// <returns>
        /// Valor booleano que indica si la operación de agregar un nuevo registro a la tabla
        /// "Estadistica" fue exitosa o no.
        /// </returns>
        public bool AgregarEstadistica(Estadisticas estadistica)
        {
            bool rta = true;

            try
            {
                string sql = "INSERT INTO Estadistica (PartidasJugadas,PartidasGanadas,PorcentajeGanadas) VALUES(";
                sql = sql + estadistica.PartidasJugadas + "," + estadistica.PartidasGanadas + ")";

                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sql;
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    rta = false;
                }
            }
            catch (Exception e)
            {
                rta = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return rta;
        }

        /// <summary>
        /// La función guarda estadísticas para un usuario en una base de datos.
        /// </summary>
        /// <param name="Estadisticas">Una clase que representa estadísticas para un usuario, con
        /// propiedades para Id (ID de usuario), PartidasJugadas (número de juegos jugados) y
        /// PartidasGanadas (número de juegos ganados).</param>
        /// <returns>
        /// Un valor booleano que indica si las estadísticas se guardaron correctamente o no.
        /// </returns>
        public bool GuardarEstadisticas(Estadisticas estadistica)
        {
            bool rta = true;

            try
            {
                this.comando = new SqlCommand();

                this.comando.Parameters.AddWithValue("@IdUsuario", estadistica.Id);
                this.comando.Parameters.AddWithValue("@PartidasJugadas", estadistica.PartidasJugadas);
                this.comando.Parameters.AddWithValue("@PartidasGanadas", estadistica.PartidasGanadas);

                string sql = "UPDATE Estadistica ";
                sql += "SET PartidasJugadas = @PartidasJugadas, PartidasGanadas = @PartidasGanadas ";
                sql += "WHERE IdUsuario = @IdUsuario";

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sql;
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    rta = false;
                }
            }
            catch (Exception e)
            {
                rta = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return rta;
        }

        /// <summary>
        /// Esta función actualiza un registro en una tabla de base de datos con los parámetros
        /// proporcionados y devuelve un valor booleano que indica si la operación se realizó
        /// correctamente.
        /// </summary>
        /// <param name="Salas">una clase u objeto que contiene información sobre una sala de juegos o
        /// lobby, como la identificación del creador, el estado actual, los puntos para el jugador 1 y
        /// 2, los turnos restantes y el límite de tiempo.</param>
        /// <returns>
        /// Un valor booleano.
        /// </returns>
        public bool GuardarYSalir(Salas param)
        {
            bool rta = true;

            try
            {
                this.comando = new SqlCommand();

                this.comando.Parameters.AddWithValue("@CreadorID", param.Creador);
                this.comando.Parameters.AddWithValue("@EstadoSala", param.Estado);
                this.comando.Parameters.AddWithValue("@PuntosJ1", param.PuntosJ1);
                this.comando.Parameters.AddWithValue("@PuntosJ2", param.PuntosJ2);
                this.comando.Parameters.AddWithValue("@TurnosRestantes", param.TurnosRestantes1);
                this.comando.Parameters.AddWithValue("@TiempoDePartida", param.TiempoDePartida1);
                this.comando.Parameters.AddWithValue("@ID", param.IDSala1);

                string sql = "UPDATE Salas ";
                sql += "SET CreadorID = @CreadorID, EstadoSala = @EstadoSala, PuntosJ1 = @PuntosJ1, PuntosJ2 = @PuntosJ2, TurnosRestantes = @TurnosRestantes, TiempoDePartida = @TiempoDePartida ";
                sql += "WHERE ID = @ID";

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sql;
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    rta = false;
                }
            }
            catch (Exception)
            {
                rta = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return rta;
        }

        /// <summary>
        /// Esta función recupera estadísticas de un usuario por su ID de una base de datos.
        /// </summary>
        /// <param name="index">El parámetro de índice es un valor entero que representa el IdUsuario
        /// (ID de usuario) para el que se recuperan las estadísticas de la base de datos.</param>
        /// <returns>
        /// Un objeto de tipo Estadísticas.
        /// </returns>
        public Estadisticas ObtenerEstadisticaPorId(int index)
        {
            Estadisticas item = new Estadisticas();

            try
            {
                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "SELECT * FROM Estadistica WHERE IdUsuario = " + index;
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    item.PartidasJugadas = lector.GetInt32(1);
                    item.PartidasGanadas = lector.GetInt32(2);
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

            return item;
        }

        /// <summary>
        /// Esta función recupera la ID de un usuario de una base de datos en función de su nombre de
        /// usuario.
        /// </summary>
        /// <param name="Usuarios">Una clase que representa a un usuario con propiedades como
        /// NombreUsuario (username).</param>
        /// <returns>
        /// El método devuelve un valor entero, que es el ID de un usuario obtenido de una base de datos
        /// SQL en función de su nombre de usuario. Si no se encuentra el usuario, el método devuelve
        /// -1.
        /// </returns>
        public int ObtenerIDUsuario(Usuarios usuario)
        {
            int idDevuelto = -1;
            try
            {
                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "SELECT ID FROM Usuarios WHERE nombreUsuario = '" + usuario.NombreUsuario + "'";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.lector = comando.ExecuteReader();

                if (lector.Read())
                {
                    idDevuelto = lector.GetInt32(0);
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

            return idDevuelto;
        }

        /// <summary>
        /// Esta función recupera estadísticas de un usuario con una ID determinada de una base de
        /// datos.
        /// </summary>
        /// <param name="index">El parámetro de índice es un valor entero que representa el ID del
        /// usuario cuyas estadísticas se recuperan de la base de datos.</param>
        /// <returns>
        /// Un objeto de tipo Estadísticas.
        /// </returns>
        public Estadisticas ObtenerIDUsuarioEstadistica(int index)
        {
            Estadisticas item = new Estadisticas();

            try
            {
                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "SELECT * FROM Estadistica WHERE IdUsuario = " + index;
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    item.Id = lector.GetInt32(0);
                    item.PartidasJugadas = lector.GetInt32(1);
                    item.PartidasGanadas = lector.GetInt32(2);
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

            return item;
        }

        /// <summary>
        /// Esta función recupera una lista de datos de una tabla de base de datos llamada "Salas" y la
        /// devuelve como una lista de objetos de tipo "Salas".
        /// </summary>
        /// <returns>
        /// Una lista de objetos de tipo "Salas".
        /// </returns>
        public List<Salas> ObtenerListaDatoSalas()
        {
            List<Salas> lista = new List<Salas>();

            try
            {
                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "SELECT b.nombreUsuario,a.EstadoSala,a.PuntosJ1,a.PuntosJ2,a.TurnosRestantes,a.TiempoDePartida,a.ID,a.CreadorID FROM Salas a left join Usuarios b on b.id=a.CreadorID";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Salas item = new Salas();

                    item.CreadorUsername = lector[0].ToString();
                    item.Estado = lector[1].ToString();
                    item.PuntosJ1 = lector.GetInt32(2);
                    item.PuntosJ2 = lector.GetInt32(3);
                    item.TurnosRestantes1 = lector.GetInt32(4);
                    item.TiempoDePartida1 = lector[5].ToString();
                    item.IDSala1 = lector.GetInt32(6);
                    item.Creador = lector.GetInt32(7);

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

        /// <summary>
        /// Esta función recupera una lista de estadísticas de todos los usuarios, incluida la cantidad
        /// de juegos jugados y ganados, de una base de datos.
        /// </summary>
        /// <returns>
        /// Una lista de objetos de tipo Estadísticas, que contiene información sobre la cantidad de
        /// juegos jugados y ganados por cada usuario, así como su ID de usuario y nombre de usuario.
        /// </returns>
        public List<Estadisticas> ObtenerListaEstadisticasEntera()
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
    }
}