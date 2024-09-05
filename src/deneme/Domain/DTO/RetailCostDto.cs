using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO;
public class RetailCostDto
{
    public string currency { get; set; } // Para birimi
    public string? discount { get; set; } // İndirim (isteğe bağlı)
    public string shipping { get; set; } // Kargo maliyeti
    public string? tax { get; set; } // Vergi (isteğe bağlı)
}

