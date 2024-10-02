using NArchitecture.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO;
public class ShippingRateDto : IDto
{
    public ShippingRateRecipientDto ShippingRateRecipient { get; set; }

    public List<ShippingRateOrderItemDto> ShippingRateOrderItems { get; set;}

    public string? currency { get; set; }
}
