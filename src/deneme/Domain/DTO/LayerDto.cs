using NArchitecture.Core.Application.Dtos;

namespace Domain.DTO;

public class LayerDto : IDto
{
    public string type { get; set; } // Katman tipi (ör. dosya, metin)
    public string url { get; set; } // Katman dosya URL'si (tipi dosya ise)
    //public List<LayerOptionDto>? layer_options { get; set; } // Katman seçenekleri (isteğe bağlı)
    public LayerPositionDto position { get; set; } // Katman pozisyonu
}