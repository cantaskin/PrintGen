using NArchitecture.Core.Application.Dtos;

namespace Domain.DTO;
public class MockupDto : IDto
{
    public string format { get; set; } = "png";

    public List<MockupProductDto> products { get; set; }
}
