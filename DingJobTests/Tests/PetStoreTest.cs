using System.Collections.Generic;
using IO.Swagger.Api;
using IO.Swagger.Model;
using log4net;
using NUnit.Framework;
using static IO.Swagger.Model.Pet;

namespace DingJobTests.Tests
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

        [Test, Order(1)]
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

        [Test, Order(2)]
        public void PetCanBeReadTest()
        {
            // Arrange
            List<Pet> pets = this.instance.FindPetsByTags(new List<string>() { "Domestic" });
            Pet pet = pets.Find(currentPet => currentPet.Name.Equals("Kaiser"));

            // Assert
            Assert.NotNull(pet);
        }

        [Test, Order(3)]
        public void PetCanBeUpdatedTest()
        {
            // Arrange 
            List<Pet> pets = this.instance.FindPetsByTags(new List<string>() {"Domestic"});
            Pet pet = pets.Find(currentPet => currentPet.Name.Equals("Kaiser"));

            pet.Name = "Kaiser The Great";

            this.instance.UpdatePet(pet);

            pets = this.instance.FindPetsByTags(new List<string>() { "Domestic" });
            pet = pets.Find(currentPet => currentPet.Name.Equals("Kaiser The Great"));

            // Assert
            Assert.AreEqual(pet.Name, "Kaiser The Great");
            Assert.AreEqual(pet.Id, 10);
            Assert.AreEqual(pet.Status, StatusEnum.Pending);
        }

        [Test, Order(4)]
        public void PetCanBeDeletedTest()
        {
            // Arrange 
            List<Pet> pets = this.instance.FindPetsByTags(new List<string>() { "Domestic" });
            Pet pet = pets.Find(currentPet => currentPet.Name.Equals("Kaiser The Great"));

            Assert.NotNull(pets);

            // Act
            this.instance.DeletePet(pet.Id, "special-key");
            pets = this.instance.FindPetsByTags(new List<string>() { "Domestic" });

            // Assert
            Assert.AreEqual(pets.Count, 0);
        }

    }
}
