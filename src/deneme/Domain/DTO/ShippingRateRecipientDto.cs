using NArchitecture.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO;
public class ShippingRateRecipientDto : IDto
{
    public required string address1 { get; set; }

    public string? address2 { get; set; }

    public required string city { get; set; }


    public string? state_code { get; set; }

    public required string country_code { get; set; }

    public string? zip { get; set; }
}
