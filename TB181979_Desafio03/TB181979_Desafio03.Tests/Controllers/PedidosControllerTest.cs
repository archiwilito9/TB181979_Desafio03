using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TB181979_Desafio03.Models;
using TB181979_Desafio03.Controllers;

namespace TB181979_Desafio03.Tests.Controllers
{
    [TestClass]
    public class PedidosControllerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        public void AgregarFechaNoRepetida()
        {
            // Arrange
            pedidoesController controller = new pedidoesController();
            var pedido = new pedido()
            {
                fechaPedido = Convert.ToDateTime("12/11/2021")

            };
            // Act
            var result = controller.Agregar(pedido);
            // Assert
            Assert.AreEqual(5, result);
        }
        [TestMethod]
        public void NoAgregarFechaRepetida()
        {
            // Arrange
            pedidoesController controller = new pedidoesController();
            var pedido = new pedido()
            {
                fechaPedido = Convert.ToDateTime("11/09/2021")
            };
            // Act
            var result = controller.Agregar(pedido);
            // Assert
            Assert.AreEqual(4, result);
        }
        [TestMethod]
        public void NoAgregarFechaMayorAhoy()
        {
            // Arrange
            pedidoesController controller = new pedidoesController();
            var pedido = new pedido()
            {
                fechaPedido = Convert.ToDateTime("12/11/2021")
            };
            // Act
            var result = controller.Agregar(pedido);
            // Assert
            Assert.AreEqual(5, result);
        }
        [TestMethod]
        public void NoAgregarFechaMenorAHoy()
        {
            // Arrange
            pedidoesController controller = new pedidoesController();
            var pedido = new pedido()
            {
                fechaPedido = Convert.ToDateTime("13/09/2021")
            };
            // Act
            var result = controller.Agregar(pedido);
            // Assert
            Assert.AreEqual(6, result);
        }
        [TestMethod]
        public void NoAgregarFechaConDiaDiferente()
        {
            // Arrange
            pedidoesController controller = new pedidoesController();
            var pedido = new pedido()
            {
                fechaPedido = Convert.ToDateTime("12/11/2021")
            };
            // Act
            var result = controller.Agregar(pedido);
            // Assert
            Assert.AreEqual(7, result);
        }
        [TestMethod]
        public void NoAgregarAñoMayorQueAñoActual()
        {
            // Arrange
            pedidoesController controller = new pedidoesController();
            var pedido = new pedido()
            {
                fechaPedido = Convert.ToDateTime("13/09/2021")
            };
            // Act
            var result = controller.Agregar(pedido);
            // Assert
            Assert.AreEqual(5, result);
        }
    }
}
