using NArchitecture.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO;

public class AddressDto : IDto
{
    public string name { get; set; } // Alıcının adı
    public string? company { get; set; } // Şirket adı (isteğe bağlı)
    public string address1 { get; set; } // Adres satırı 1
    public string? address2 { get; set; } // Adres satırı 2 (isteğe bağlı)
    public string city { get; set; } // Şehir
    public string state_code { get; set; } // Eyalet kodu
    public string? state_name { get; set; } // Eyalet adı (isteğe bağlı)
    public string country_code { get; set; } // Ülke kodu
    public string country_name { get; set; } // Ülke adı
    public string zip { get; set; } // Posta kodu
    public string? phone { get; set; } // Telefon numarası (isteğe bağlı)
    public string email { get; set; } // E-posta adresi
    public string? tax_number { get; set; }
} // Vergi numarası (isteğe bağlı)

