using Demo.Application.Abstractions;
using Demo.Application.Features.GrossWrittenPremium.Queries;
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
                new GrossWrittenPremium { Year = 2007, Amount = 200m, LineOfBusiness = LineOfBusiness.Property, Country = Country.Ae },
                new GrossWrittenPremium { Year = 2008, Amount = 100m, LineOfBusiness = LineOfBusiness.Property, Country = Country.Ae },
                new GrossWrittenPremium { Year = 2009, Amount = 200m, LineOfBusiness = LineOfBusiness.Property, Country = Country.Ae },
                new GrossWrittenPremium { Year = 2016, Amount = 200m, LineOfBusiness = LineOfBusiness.Property, Country = Country.Ae },

                new GrossWrittenPremium { Year = 2015, Amount = 200m, LineOfBusiness = LineOfBusiness.Property, Country = Country.Us },
                new GrossWrittenPremium { Year = 2015, Amount = 200m, LineOfBusiness = LineOfBusiness.Liability, Country = Country.Ae }
            };

            var mockSet = testData.AsQueryable().BuildMockDbSet();
            var mockContext = new Mock<IApplicationDbContext>();
            mockContext.Setup(x => x.GrossWrittenPremiums).Returns(mockSet.Object);

            var handler = new GetAveragePerCountryQueryHandler(mockContext.Object);
            var query = new GetAveragePerCountryQuery
            {
                Country = Country.Ae,
                LinesOfBusiness = [ LineOfBusiness.Property ],
                YearSince = 2008,
                YearUntil = 2015
            };

            var result = await handler.Handle(query, CancellationToken.None);
            
            Assert.AreEqual(150, result[LineOfBusiness.Property]);
        }
    }
}
