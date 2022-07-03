using System.Collections.Generic;
using System.Threading.Tasks;
using Cat.Data.Models;
using Cat.Data.Repositories;
using Cat.Domain.Services;
using Moq;
using NUnit.Framework;

namespace Cat.Domain.Tests
{
    [TestFixture]
    public class CatServiceTests
    {
        private CatService _catService;
        private Mock<ICatRepository> _catRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _catRepositoryMock = new Mock<ICatRepository>();
            _catService = new CatService(_catRepositoryMock.Object);
        }
        
        [Test]
        public async Task RetrieveByName_GivenName_ReturnsCat()
        {
            //Arrange
            var expectedCat = new CatData("Bumble", 4, Classification.Tabby);
            (_catRepositoryMock).Setup(x => x.RetrieveByName("Bumble")).ReturnsAsync(expectedCat);

            //Act
            var result = await _catService.RetrieveByName("Bumble");

            //Assert
            Assert.AreEqual(expectedCat, result);
        }
        
        [Test]
        public async Task RetrieveByClassification_GivenClassification_ReturnsAllCatsForClassification()
        {
            //Arrange
            var expectedCats = new List<CatData>
            {
                new CatData("Bumble", 4, Classification.Tabby),
                new CatData("Bramble", 5, Classification.Tabby)
            };
            _catRepositoryMock.Setup(x => x.RetrieveByClassification(Classification.Tabby)).ReturnsAsync(expectedCats);

            //Act
            var result = await _catService.RetrieveByClassification(Classification.Tabby);

            //Assert
            Assert.AreEqual(expectedCats, result);
        }

        [Test]
        public async Task RetrieveAll_ReturnsAllCats()
        {
            //Arrange
            var expectedCats = new List<CatData>
            {
                new CatData("Bumble", 4, Classification.Tabby),
                new CatData("Kit", 3, Classification.BlackAndWhite),
                new CatData("Sky", 8, Classification.Tortoiseshell)
            };
            _catRepositoryMock.Setup(x => x.RetrieveAll()).ReturnsAsync(expectedCats);

            //Act
            var result = await _catService.RetrieveAll();

            //Assert
            Assert.AreEqual(expectedCats, result);
        }
    }
}