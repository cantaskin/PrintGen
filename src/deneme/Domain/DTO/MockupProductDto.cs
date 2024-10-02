using Domain.Entities;
using NArchitecture.Core.Application.Dtos;

namespace Domain.DTO;
public class MockupProductDto : IDto
{
    public required string source { get; set; }
    public required List<int> mockup_style_ids { get; set; }

    public required int catalog_product_id { get; set; }

    public required List<int> catalog_variant_ids { get; set; }

    public string orientation { get; set; }

    public required List<PlacementDto> placements { get; set; }

    public List<OptionDto>? product_options { get; set; }
}
