using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Entidades
{
    public class Archivos
    {
        #region Atributos

        private static BaseDeDatos ado = new BaseDeDatos();
        private static List<Estadisticas> listaEstadisticas = new List<Estadisticas>();
        private static List<Salas> listaSalas = new List<Salas>();
        private static List<Usuarios> listaUsuarios = new List<Usuarios>();

        #endregion Atributos

        #region Metodos

        /// <summary>
        /// El Metodo guarda listas de estadísticas, salas y usuarios en formato JSON en sus
        /// respectivos archivos.
        /// </summary>
        public static void GuardarListasEnJSON()
        {
            string rutaEstadisticas = "..\\..\\..\\..\\Archivos\\Estadisticas.json";
            string rutaSalas = "..\\..\\..\\..\\Archivos\\Salas.json";
            string rutaUsuarios = "..\\..\\..\\..\\Archivos\\Usuarios.json";

            listaEstadisticas = ConseguirListaEstadisticas();
            string jsonEstadisticas = JsonConvert.SerializeObject(listaEstadisticas);
            File.WriteAllText(rutaEstadisticas, jsonEstadisticas);

            listaSalas = ConseguirListaSalas();
            string jsonSalas = JsonConvert.SerializeObject(listaSalas);
            File.WriteAllText(rutaSalas, jsonSalas);

            listaUsuarios = ConseguirListaUsuarios();
            string jsonUsuarios = JsonConvert.SerializeObject(listaUsuarios);
            File.WriteAllText(rutaUsuarios, jsonUsuarios);
        }

        /// <summary>
        /// El Metodo guarda listas de estadísticas, salas y usuarios en archivos de texto.
        /// </summary>
        public static void GuardarListasEnTXT()
        {
            string rutaEstadisticas = "..\\..\\..\\..\\Archivos\\Estadisticas.txt";
            string rutaSalas = "..\\..\\..\\..\\Archivos\\Salas.txt";
            string rutaUsuarios = "..\\..\\..\\..\\Archivos\\Usuarios.txt";

            listaEstadisticas = ConseguirListaEstadisticas();
            StringBuilder sbEstadisticas = new StringBuilder();
            foreach (Estadisticas item in listaEstadisticas)
            {
                string contenido = $"ID: {item.Id} - Nombre de Usuario: {item.NombreUsuario} - Partidas Ganadas: {item.PartidasGanadas} - Partidas Jugadas: {item.PartidasJugadas}";
                sbEstadisticas.AppendLine(contenido);
            }
            File.WriteAllText(rutaEstadisticas, sbEstadisticas.ToString());

            listaSalas = ConseguirListaSalas();
            StringBuilder sbSalas = new StringBuilder();
            foreach (Salas item in listaSalas)
            {
                string contenido = $"ID Sala: {item.IDSala} - Creador: {item.Creador} - Nombre del Creador: {item.CreadorNombre} - Estado: {item.Estado} - Puntos Jugador 1: {item.PuntosJ1} - Puntos Jugador 2: {item.PuntosJ2} - Turnos Restantes: {item.TurnosRestantes1}- Tiempo de Partida: {item.TiempoDePartida1}\n";
                sbSalas.AppendLine(contenido);
            }
            File.WriteAllText(rutaSalas, sbSalas.ToString());

            listaUsuarios = ConseguirListaUsuarios();
            StringBuilder sbUsuarios = new StringBuilder();
            foreach (Usuarios item in listaUsuarios)
            {
                string contenido = $"Nombre de usuario: {item.NombreUsuario} - Clave: {item.Clave}";
                sbUsuarios.AppendLine(contenido);
            }
            File.WriteAllText(rutaUsuarios, sbUsuarios.ToString());
        }

        /// <summary>
        /// El Metodo guarda listas de estadísticas, salas y usuarios en formato XML en rutas de
        /// archivo específicas.
        /// </summary>
        public static void GuardarListasEnXML()
        {
            string rutaEstadisticas = "..\\..\\..\\..\\Archivos\\Estadisticas.xml";
            string rutaSalas = "..\\..\\..\\..\\Archivos\\Salas.xml";
            string rutaUsuarios = "..\\..\\..\\..\\Archivos\\Usuarios.xml";

            listaEstadisticas = ConseguirListaEstadisticas();
            XmlSerializer serializerEstadisticas = new XmlSerializer(typeof(List<Estadisticas>));
            using (TextWriter writer = new StreamWriter(rutaEstadisticas))
            {
                serializerEstadisticas.Serialize(writer, listaEstadisticas);
            }

            listaSalas = ConseguirListaSalas();
            XmlSerializer serializerSalas = new XmlSerializer(typeof(List<Salas>));
            using (TextWriter writer = new StreamWriter(rutaSalas))
            {
                serializerSalas.Serialize(writer, listaSalas);
            }

            listaUsuarios = ConseguirListaUsuarios();
            XmlSerializer serializerUsuarios = new XmlSerializer(typeof(List<Usuarios>));
            using (TextWriter writer = new StreamWriter(rutaUsuarios))
            {
                serializerUsuarios.Serialize(writer, listaUsuarios);
            }
        }

        /// <summary>
        /// El Metodo devuelve una lista de estadísticas obtenidas de una base de datos utilizando
        /// ADO.NET.
        /// </summary>
        /// <returns>
        /// Una lista de objetos de tipo Estadísticas.
        /// </returns>
        private static List<Estadisticas> ConseguirListaEstadisticas()
        {
            List<Estadisticas> lista;
            lista = ado.ObtenerListaEstadisticasEntera();
            return lista;
        }

        /// <summary>
        /// El Metodo devuelve una lista de todas las habitaciones obtenidas de una base de datos.
        /// </summary>
        /// <returns>
        /// Una lista de objetos de tipo "Salas".
        /// </returns>
        private static List<Salas> ConseguirListaSalas()
        {
            List<Salas> lista;
            lista = ado.ObtenerListaSalasEntera();
            return lista;
        }

        /// <summary>
        /// El Metodo devuelve una lista de todos los usuarios obtenidos de una base de datos usando
        /// ADO.NET.
        /// </summary>
        /// <returns>
        /// El método `GetListUsers` devuelve una `Lista` de `Usuarios`.
        /// </returns>
        private static List<Usuarios> ConseguirListaUsuarios()
        {
            List<Usuarios> lista;
            lista = ado.ObtenerListaUsuariosEntera();
            return lista;
        }

        #endregion Metodos
    }
}