using System.Collections.Generic;
using System.Threading.Tasks;
using Cat.Domain.Model;
using Cat.Domain.Port;
using Cat.Domain.Services;
using Moq;
using NUnit.Framework;

namespace Cat.Domain.Tests
{
    [TestFixture]
    public class CatServiceTests
    {
        private CatService _catService;
        private Mock<ICatAdapter> _catRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _catRepositoryMock = new Mock<ICatAdapter>();
            _catService = new CatService(_catRepositoryMock.Object);
        }
        
        [Test]
        public async Task RetrieveByName_GivenName_ReturnsCat()
        {
            //Arrange
            var expectedCat = new DomainCat("Bumble", 4, Classification.Tabby);
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
            var expectedCats = new List<DomainCat>
            {
                new DomainCat("Bumble", 4, Classification.Tabby),
                new DomainCat("Bramble", 5, Classification.Tabby)
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
            var expectedCats = new List<DomainCat>
            {
                new DomainCat("Bumble", 4, Classification.Tabby),
                new DomainCat("Kit", 3, Classification.BlackAndWhite),
                new DomainCat("Sky", 8, Classification.Tortoiseshell)
            };
            _catRepositoryMock.Setup(x => x.RetrieveAll()).ReturnsAsync(expectedCats);

            //Act
            var result = await _catService.RetrieveAll();

            //Assert
            Assert.AreEqual(expectedCats, result);
        }
    }
}