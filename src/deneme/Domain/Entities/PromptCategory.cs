﻿using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class PromptCategory  : Entity<Guid> 
{
    public string Name { get; set; }

    public string Description { get; set; }

    public List<Prompt> Prompts { get; set; }

    public PromptCategory()
    {
        Id = Guid.NewGuid();
    }
}
