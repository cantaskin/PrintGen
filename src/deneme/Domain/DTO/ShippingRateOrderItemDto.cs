using NArchitecture.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO;
public class ShippingRateOrderItemDto : IDto
{
    public required string source { get; set; } = "catalog";
    public required int quantity { get; set; }

    public required int catalog_variant_id { get; set; }
}
