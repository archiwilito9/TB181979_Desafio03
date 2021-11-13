using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TB181979_Desafio03.Controllers;
using TB181979_Desafio03.Models;

namespace TB181979_Desafio03.Tests.Controllers
{
    [TestClass]
    public class ClientesControllerTest
    {
        [TestMethod]
        public void AgregarClienteNoRepetido()
        {
            // Arrange
            clientesController controller = new clientesController();
            var cliente = new cliente()
            {
                nombres = "mario ramirez",
                primerApellido = "Mario",
                segundoApellido = "Melendez",
                Telefono = "71277380",
                email = "mario@yahoo.com",

            };
            // Act
            var result = controller.Agregar(cliente);
            // Assert
            Assert.AreEqual(4, result);
        }
        [TestMethod]
        public void NoAgregarClienteRepetido()
        {
            // Arrange
            clientesController controller = new clientesController();
            var cliente = new cliente()
            {
                nombres = "mario melendez",
                primerApellido = "Mario",
                segundoApellido = "Melendez",
                Telefono = "71277380",
                email = "mario@yahoo.com",
            };
            // Act
            var result = controller.Agregar(cliente);
            // Assert
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void NoAgregarClienteConNombreVacio()
        {
            // Arrange
            clientesController controller = new clientesController();
            var cliente = new cliente()
            {

                nombres = ""
            };
            // Act
            var result = controller.Agregar(cliente);
            // Assert
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void NoAgregarClienteConEmailVacio()
        {
            // Arrange
            clientesController controller = new clientesController();
            var cliente = new cliente()
            {
                email = ""
            };
            // Act
            var result = controller.Agregar(cliente);
            // Assert
            Assert.AreEqual(6, result);
        }
        [TestMethod]
        public void NoAgregarClienteConTelefonoVacio()
        {
            // Arrange
            clientesController controller = new clientesController();
            var cliente = new cliente()
            {
                Telefono = ""
            };
            // Act
            var result = controller.Agregar(cliente);
            // Assert
            Assert.AreEqual(7, result);
        }
        [TestMethod]
        public void NoAgregarClienteConTelefonoIncorrecto()
        {
            // Arrange
            clientesController controller = new clientesController();
            var cliente = new cliente()
            {
                Telefono = "ABCDEFGH"
            };
            // Act
            var result = controller.Agregar(cliente);
            // Assert
            Assert.AreEqual(5, result);
        }

    }
}
