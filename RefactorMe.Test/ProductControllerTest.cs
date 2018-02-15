using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactorMe.Controllers;
using RefactorMe.Data.Entities;
using RefactorMe.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace RefactorMe.Test
{
    [TestClass]
    public class ProductControllerTest : BaseControllerTest
    {
        [TestMethod]
        public void TestGetAllProducts()
        {
            // Agrange
            var controller = new ProductsController(this.mockService.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var response = controller.Get();
            
            // Assert
            Assert.IsNotNull(response);

            ProductsReturn productReturn = new ProductsReturn();
            Assert.IsTrue(response.TryGetContentValue(out productReturn));

            Assert.IsNotNull(productReturn.Items);

            var products = productReturn.Items as List<Product>;
            Assert.AreEqual(TestingDataSource.ProductModelList.Count, products.Count);
            Assert.AreEqual(TestingDataSource.ProductModelList[0].Name, products[0].Name);
        }
    }
}
