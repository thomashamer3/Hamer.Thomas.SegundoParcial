using System.Data.SqlClient;
using Entidades;
using System.Collections.Generic;
using Hamer.Thomas.SegundoParcial;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

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


             
    }

}