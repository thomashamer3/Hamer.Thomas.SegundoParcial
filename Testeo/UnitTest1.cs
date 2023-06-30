using Entidades;

namespace Testeo
{
    [TestClass]
    public class UnitTest1
    {
        private BaseDeDatos baseDeDatos = new BaseDeDatos();

        [TestMethod]
        public void CheckearPoker()
        {
            Dados dado1 = new(1, true);
            Dados dado2 = new(1, true);
            Dados dado3 = new(1, true);
            Dados dado4 = new(1, true);
            Dados dado5 = new(5, true);

            bool validacion = false;

            if (dado1 == dado2 && dado1 == dado3 && dado1 == dado4)
            {
                validacion = true;
            }

            Assert.IsFalse(validacion);
        }

        [TestMethod]
        public void GetDados()
        {
            // Arrange
            List<Dados> listaDados;

            // Act
            listaDados = Dados.GetDados();

            // Assert
            Assert.AreEqual(5, listaDados.Count);
            foreach (Dados dado in listaDados)
            {
                Assert.IsTrue(dado.Estado);
            }
        }

        [TestMethod]
        public void TestAgregarDato()
        {
            // Arrange
            Usuarios usuarioNuevo = new Usuarios
            {
                NombreUsuario = "usuarioNuevo",
                Clave = "123456"
            };

            bool expectedRta = true;

            // Act
            bool actualRta = baseDeDatos.AgregarDato(usuarioNuevo);

            // Assert
            Assert.AreEqual(expectedRta, actualRta);
        }

        [TestMethod]
        public void TestAgregarDatoSala()
        {
            // Arrange
            Salas salaNueva = new Salas
            {
                Creador = 1,
                Estado = "Activa",
                PuntosJ1 = 0,
                PuntosJ2 = 0,
                TurnosRestantes1 = 10,
                TiempoDePartida1 = "00:30:00"
            };

            bool expectedRta = true;

            // Act
            bool actualRta = baseDeDatos.AgregarDatoSala(salaNueva);

            // Assert
            Assert.AreEqual(expectedRta, actualRta);
        }

        [TestMethod]
        public void TestGuardarListasEnJSON()
        {
            // Arrange
            string folderPath = AppDomain.CurrentDomain.BaseDirectory;
            string rutaEstadisticas = Path.Combine(folderPath, "Estadisticas.json");
            string rutaSalas = Path.Combine(folderPath, "Salas.json");
            string rutaUsuarios = Path.Combine(folderPath, "Usuarios.json");

            // Act
            Archivos.GuardarListasEnJSON();

            // Assert
            Assert.IsTrue(File.Exists(rutaEstadisticas));
            Assert.IsTrue(File.Exists(rutaSalas));
            Assert.IsTrue(File.Exists(rutaUsuarios));
        }

        [TestMethod]
        public void TestGuardarListasEnTXT()
        {
            // Arrange
            string folderPath = AppDomain.CurrentDomain.BaseDirectory;
            string rutaEstadisticas = Path.Combine(folderPath, "Estadisticas.txt");
            string rutaSalas = Path.Combine(folderPath, "Salas.txt");
            string rutaUsuarios = Path.Combine(folderPath, "Usuarios.txt");

            // Act
            Archivos.GuardarListasEnTXT();

            // Assert
            Assert.IsTrue(File.Exists(rutaEstadisticas));
            Assert.IsTrue(File.Exists(rutaSalas));
            Assert.IsTrue(File.Exists(rutaUsuarios));

            // Clean up
            File.Delete(rutaEstadisticas);
            File.Delete(rutaSalas);
            File.Delete(rutaUsuarios);
        }

        [TestMethod]
        public void TestGuardarListasEnXML()
        {
            // Arrange
            string folderPath = AppDomain.CurrentDomain.BaseDirectory;
            string rutaEstadisticas = Path.Combine(folderPath, "Estadisticas.xml");
            string rutaSalas = Path.Combine(folderPath, "Salas.xml");
            string rutaUsuarios = Path.Combine(folderPath, "Usuarios.xml");

            // Act
            Archivos.GuardarListasEnXML();

            // Assert
            Assert.IsTrue(File.Exists(rutaEstadisticas));
            Assert.IsTrue(File.Exists(rutaSalas));
            Assert.IsTrue(File.Exists(rutaUsuarios));

            // Clean up
            File.Delete(rutaEstadisticas);
            File.Delete(rutaSalas);
            File.Delete(rutaUsuarios);
        }

        [TestMethod]
        public void TestProbarConexion()
        {
            // Arrange

            // Act
            bool isConnected = baseDeDatos.ProbarConexion();

            // Assert
            Assert.IsTrue(isConnected);
        }

        [TestMethod]
        public void TestSelecionarEstadisticas()
        {
            // Arrange
            AdoEstadisticas estadisticas = new AdoEstadisticas();

            // Act
            List<Estadisticas> lista = estadisticas.Selecionar();

            // Assert
            Assert.IsNotNull(lista);
            Assert.IsTrue(lista.Count > 0);
        }

        [TestMethod]
        public void TestSelecionarUsuarios()
        {
            // Arrange
            AdoUsuarios adoUsuarios = new AdoUsuarios();

            // Act
            List<Usuarios> lista = adoUsuarios.Selecionar();

            // Assert
            Assert.IsNotNull(lista);
            Assert.IsTrue(lista.Count > 0);
        }
    }
}