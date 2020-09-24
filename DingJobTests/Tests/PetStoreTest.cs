using IO.Swagger.Api;
using IO.Swagger.Model;
using log4net;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static IO.Swagger.Model.Pet;

namespace DingJobTests.PetTests
{
    [TestFixture]
    public class PetStoreTest
    {
        private PetApi instance;

        private readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

        [SetUp]
        public void SetUp()
        {
            instance = new PetApi();
        }

        [Test]
        public void PetCanBeAddedWithCategoryTest()
        {
            // Arrange
            Pet petToAdd = new Pet(
                id: 10,
                category: new Category(10, "Dog"),
                name: "Kaiser",
                photoUrls: new List<string>() { "https://www.google.com", "https://cat.com/" },
                tags: new List<Tag>() { new Tag(10, "Domestic") },
                status: StatusEnum.Pending
            );

            // Act
            instance.AddPet(petToAdd);
            Pet result = instance.GetPetById(petToAdd.Id);

            log.Info($"Initial Pet: {petToAdd}");
            log.Info($"Recovered Pet: {result}");

            // Assert
            Assert.AreEqual(petToAdd, result);
        }
    }
}
