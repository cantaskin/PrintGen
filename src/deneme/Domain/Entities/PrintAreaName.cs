using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class PrintAreaName : Entity<Guid>
{
    public string Name { get; set; }

    public ICollection<PrintArea>? PrintAreas { get; set; }

    public PrintAreaName()
    {
           Id = Guid.NewGuid();
           PrintAreas = new HashSet<PrintArea>();
    }
}

