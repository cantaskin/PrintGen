using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Layer : Entity<Guid>
{
    public string Type { get; set; }

    public string Url { get; set; }

    public  Guid PlacementId { get; set; }

    public Placement Placement { get; set; }

    public Guid? PositionId { get; set; }

    public Position? Position { get; set; }

    public List<Option> LayerOptions { get; set; }


   // public List<LayerOption<object>>? LayerOptions { get; set; }


    public Layer()
    {
        Id = Guid.NewGuid();
        Type = "file";
    }
}
