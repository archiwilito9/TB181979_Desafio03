using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TB181979_Desafio03.Controllers;
using TB181979_Desafio03.Models;

namespace TB181979_Desafio03.Tests.Controllers
{
    [TestClass]
    public class ProductosControllerTest
    {
        [TestMethod]
        public void TestMethod1()
        {

        }

        public void AgregarProductoNoRepetido()
        {
            // Arrange
            productoesController controller = new productoesController();
            var producto = new producto()
            {
                NombreProducto = "Churros",
                Existencias = 5,
                Precio = 6

            };
            // Act
            var result = controller.Agregar(producto);
            // Assert
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void NoAgregarProductoRepetido()
        {
            // Arrange
            productoesController controller = new productoesController();
            var producto = new producto()
            {
                NombreProducto = "Churros",
                Existencias = 5,
                Precio = 6
            };
            // Act
            var result = controller.Agregar(producto);
            // Assert
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void NoAgregarProductoConNombreVacio()
        {
            // Arrange
            productoesController controller = new productoesController();
            var producto = new producto()
            {
                NombreProducto = ""
            };
            // Act
            var result = controller.Agregar(producto);
            // Assert
            Assert.AreEqual(2, result);
        }
        [TestMethod]
        public void NoAgregarProductoConExistenciasVacias()
        {
            // Arrange
            productoesController controller = new productoesController();
            var producto = new producto()
            {
                Existencias = 0
            };
            // Act
            var result = controller.Agregar(producto);
            // Assert
            Assert.AreEqual(3, result);
        }
        [TestMethod]
        public void NoAgregarProductoConPrecioVacio()
        {
            // Arrange
            productoesController controller = new productoesController();
            var producto = new producto()
            {
                Precio = 0
            };
            // Act
            var result = controller.Agregar(producto);
            // Assert
            Assert.AreEqual(3, result);
        }
        [TestMethod]
        public void NoAgregarPrecioConValorNegativo()
        {
            // Arrange
            productoesController controller = new productoesController();
            var producto = new producto()
            {
                Precio = -2
            };
            // Act
            var result = controller.Agregar(producto);
            // Assert
            Assert.AreEqual(3, result);
        }
    }
}
