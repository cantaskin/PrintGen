﻿using NArchitecture.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO;
public class OptionStringDto : IDto
{
    public string name { get; set; }

    public string value { get; set; }
}
