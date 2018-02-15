using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactorMe.Service;
using Moq;
using System.Linq;
using RefactorMe.Data.Entities;

namespace RefactorMe.Test
{
    [TestClass]
    public abstract class BaseControllerTest
    {
        protected Mock<IProductService> mockService;

        [TestInitialize]
        public virtual void Setup()
        {
            this.mockService = new Mock<IProductService>();

            var products = TestingDataSource.ProductModelList;

            // Mock get all product
            mockService.Setup(m => m.GetAllProducts()).Returns(() =>
            {
                return products;
            });

            // Mock get products by name
            mockService.Setup(m => m.GetProductsByName(It.IsAny<string>())).Returns((string filterCriteria) =>
            {
                if (string.IsNullOrEmpty(filterCriteria))
                {
                    return products;
                }

                return products.Where(x => x.Name.Contains(filterCriteria)).ToList();
            });

            // Mock insert product
            mockService.Setup(m => m.InsertProduct(It.IsAny<Product>())).Verifiable();

            // Mock does product exist
            mockService.Setup(m => m.DoesProductExist(It.IsAny<Guid>())).Returns((Guid id) =>
            {
                return TestingDataSource.ProductModelList.Any(x => x.Id == id);
            });

            // Mock get product by id
            mockService.Setup(m => m.GetProductById(It.IsAny<Guid>())).Returns((Guid id) =>
            {
                return TestingDataSource.ProductModelList.FirstOrDefault(x => x.Id == id);
            });

            // Mock delete product
            mockService.Setup(m => m.DeleteProduct(It.IsAny<Guid>())).Verifiable();
        }
    }
}
