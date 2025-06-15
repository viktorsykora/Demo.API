using Demo.Domain;
using Demo.Infrastructure.Context;
using Demo.Shared.Enums;

namespace Demo.Infrastructure
{
    public static class DatabaseSeedHelpers
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.GrossWrittenPremiums.Any())
            {
                context.GrossWrittenPremiums.AddRange(
                    new GrossWrittenPremium { Year = 2008, Amount = 100m, LineOfBusiness = LineOfBusiness.Property, Country = Country.Ae },
                    new GrossWrittenPremium { Year = 2009, Amount = 200m, LineOfBusiness = LineOfBusiness.Property, Country = Country.Ae },
                    new GrossWrittenPremium { Year = 2009, Amount = 200m, LineOfBusiness = LineOfBusiness.Transport, Country = Country.Ae },
                    new GrossWrittenPremium { Year = 20010, Amount = 200m, LineOfBusiness = LineOfBusiness.Transport, Country = Country.Ae }
                );

                context.SaveChanges();
            }
        }
    }
}