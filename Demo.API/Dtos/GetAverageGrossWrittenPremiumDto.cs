using Demo.Shared.Enums;

namespace Demo.API.Dtos
{
    public record GetAverageGrossWrittenPremiumDto
    {
        public required Country Country { get; init; }
        public required LineOfBusiness[] Lob { get; init; }
    }
}
