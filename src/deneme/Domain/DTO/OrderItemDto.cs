using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO;
public class OrderItemDto
{
    public string source { get; set; } = "catalog"; // Varsayılan kaynak
    public int catalog_variant_id { get; set; } // Katalog varyant ID'si
    public string? external_id { get; set; } // Harici ID (isteğe bağlı)
    public int quantity { get; set; } // Ürün miktarı
    public string retail_price { get; set; } // Perakende fiyatı
    public string name { get; set; } // Ürün adı
    public List<PlacementDto> placements { get; set; } // Placement bilgileri
}



