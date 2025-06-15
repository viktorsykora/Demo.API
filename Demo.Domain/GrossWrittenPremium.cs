using Demo.Domain.Abstractions;
using Demo.Shared.Enums;

namespace Demo.Domain
{
    public class GrossWrittenPremium : EntityBase
    {
        public required Country Country { get; set; }
        public required LineOfBusiness LineOfBusiness { get; set; }
        public required decimal Amount { get; set; }
        public required int Year { get; set; }
    }
}
