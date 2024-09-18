using NArchitecture.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO;
public class PlacementDto : IDto
{
    public string placement { get; set; } // Placement adı
    public string technique { get; set; } // Teknik adı
    public List<LayerDto> layers { get; set; } // Katman bilgileri
    //public List<PlacementOptionDto>? placement_options { get; set; } // Placement seçenekleri (isteğe bağlı)
}