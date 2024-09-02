using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Position : Entity<Guid>
{
    public float Width { get; set; }

    public float Height { get; set; }

    public float Top { get; set; }
    public float Left { get; set; }

    public Guid LayerId { get; set; }
    public Layer  Layer { get; set; }
}
