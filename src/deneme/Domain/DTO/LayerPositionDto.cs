﻿using NArchitecture.Core.Application.Dtos;

namespace Domain.DTO;

public class LayerPositionDto : IDto
{
    public float width { get; set; } // Genişlik inç cinsinden
    public float height { get; set; } // Yükseklik inç cinsinden
    public float top { get; set; } // Üst pozisyon inç cinsinden
    public float left { get; set; } // Sol pozisyon inç cinsinden
}