﻿using NArchitecture.Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TemplateProducts.Command.Update;
public class UpdatedTemplateProductResponse : IResponse
{
    public Guid Id { get; set; }
}
