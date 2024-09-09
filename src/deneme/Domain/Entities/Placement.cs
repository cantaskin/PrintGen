using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Placement : Entity<Guid>
{
    public string PlacementName { get; set; }
    public string Technique { get; set; }

  //  public Guid? PlacementOptionId { get; set; }

    public Guid OrderItemId { get; set; }
    public OrderItem OrderItem { get; set; }

    public List<Layer> Layers { get; set; }

    public List<Option> PlacementOptions { get; set; }
    public Placement()
    {
        Id = Guid.NewGuid(); // Entity<Guid>'den türetildiği için bu gerekli olmayabilir
    }

    // public IPlacementOption<object>? PlacementOption { get; set; }
}
