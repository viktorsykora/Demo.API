using Demo.Application.Abstractions;
using Demo.Application.Features.GrossWrittenPremium;
using Demo.Domain;
using Demo.Shared.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockQueryable.Moq;
using Moq;

namespace Demo.Tests
{
    [TestClass]
    public class GetAveragePerCountryQueryHandlerTest
    {
        [TestMethod]
        public async Task GetAveragePerCountryQueryHandler_Must_Return_Avg()
        {
            List<GrossWrittenPremium> testData = new List<GrossWrittenPremium>
            {
                new GrossWrittenPremium { Year = 2008, Amount = 100m, LineOfBusiness = LineOfBusiness.Property, Country = Country.Ae },
                new GrossWrittenPremium { Year = 2009, Amount = 200m, LineOfBusiness = LineOfBusiness.Property, Country = Country.Ae },
                new GrossWrittenPremium { Year = 2009, Amount = 200m, LineOfBusiness = LineOfBusiness.Liability, Country = Country.Ae },                
            };

            var repositoryMock = new Mock<IGrossWrittenPremiumRepository>();
            repositoryMock.Setup(x => x.GrossWrittenPremiumsByCountryAndYear(
                It.IsAny<Country>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<LineOfBusiness[]>()))
                .ReturnsAsync(testData.ToArray());

            var sut = new GrossWrittenPremiumCalculationService(repositoryMock.Object);
            var result = await sut.GetAveragePerCountry(Country.Ae, new[] { LineOfBusiness.Property }, 2008, 2015);

            Assert.AreEqual(150, result[LineOfBusiness.Property]);
        }
    }
}
