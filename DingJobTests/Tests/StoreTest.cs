using System;
using IO.Swagger.Api;
using IO.Swagger.Model;
using log4net;
using NUnit.Framework;
using static IO.Swagger.Model.Order;

namespace DingJobTests.Tests
{
    class StoreTest
    {
        private StoreApi instance;

        private readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

        [SetUp]
        public void SetUp()
        {
            instance = new StoreApi();
        }

        [Test]
        public void StoreCanBeAddedWithStatusTest()
        {
            // Arrange
            Order order = new Order(id: 10, petId: 20, quantity: 200, DateTime.Today, StatusEnum.Approved, complete: true);

            // Act
            Order orderResult = this.instance.PlaceOrder(order);
            log.Info($"Initial Order: {order}");
            log.Info($"Recovered Order: {orderResult}");

            //Assert
            Assert.AreEqual(order, orderResult);
        }
    }
}
