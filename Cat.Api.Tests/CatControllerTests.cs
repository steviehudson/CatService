using System.Collections.Generic;
using System.Threading.Tasks;
using Cat.API.Controllers;
using Cat.Data.Models;
using Cat.Domain.Services;
using NUnit.Framework;
using Moq;

namespace Cat.Api.Tests
{
    [TestFixture]
    public class CatControllerTests
    {
        private CatController _catController;
        private Mock<ICatService> _catServiceMock;

        [SetUp]
        public void Setup()
        {
            _catServiceMock = new Mock<ICatService>();
            _catController = new CatController(_catServiceMock.Object);
        }

        [Test]
        public async Task RetrieveCatByName_GivenName_ReturnsCat()
        {
            //Arrange
            var expectedCat = new CatData("Bumble", 4, Classification.Tabby);
            _catServiceMock.Setup(x => x.RetrieveByName("Bumble")).ReturnsAsync(expectedCat);

            //Act
            var result = await _catController.RetrieveCatByName("Bumble");

            //Assert
            Assert.AreEqual(expectedCat, result);
        }

        [Test]
        public async Task RetrieveCatByClassification_GivenClassification_ReturnsAllCatsForClassification()
        {
            //Arrange
            var expectedCats = new List<CatData>
            {
                new CatData("Bumble", 4, Classification.Tabby),
                new CatData("Bramble", 5, Classification.Tabby)
            };
            _catServiceMock.Setup(x => x.RetrieveByClassification(Classification.Tabby)).ReturnsAsync(expectedCats);

            //Act
            var result = await _catController.RetrieveCatsByClassification(Classification.Tabby.ToString());

            //Assert
            Assert.AreEqual(expectedCats, result);
        }

        [Test]
        public async Task RetrieveAllCats_ReturnsAllCats()
        {
            //Arrange
            var expectedCats = new List<CatData>
            {
                new CatData("Bumble", 4, Classification.Tabby),
                new CatData("Kit", 3, Classification.BlackAndWhite),
                new CatData("Sky", 8, Classification.Tortoiseshell)
            };
            _catServiceMock.Setup(x => x.RetrieveAll()).ReturnsAsync(expectedCats);

            //Act
            var result = await _catController.RetrieveAllCats();

            //Assert
            Assert.AreEqual(expectedCats, result);
        }
    }
}