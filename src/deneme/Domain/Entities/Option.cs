using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Option : Entity<Guid>
{
    public string Name { get; set; }

    public string Value { get; set; }

    public Guid? LayerId { get; set; }
    public Layer Layer { get; set; }


    public Guid? OrderItemId { get; set; }

    public OrderItem OrderItem { get; set; }

    public Guid? PlacementId { get; set; }
    public Placement Placement { get; set; }
}
