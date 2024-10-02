using NArchitecture.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO;
public class OptionDto : IDto
{
    public string name { get; set; }

    public object value { get; set; }
}
