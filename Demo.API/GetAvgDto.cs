using Demo.Shared.Enums;

namespace Demo.API
{
    public record GetAvgDto
    {
        public required string Country { get; init; }
        public required LineOfBusiness[] Lob { get; init; }
    }
}
