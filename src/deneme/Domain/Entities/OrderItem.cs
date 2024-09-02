using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class OrderItem : Entity<Guid>
{
    public string Source { get; set; } = "catalog";
    public int CatalogVariantId { get; set; }

    public string? ExternalId { get; set; }

    public int Quantity { get; set; } 

    public string? RetailPrice { get; set; }

    public string? Name { get; set; }

    public Guid PlacementId { get; set; }

    public Guid OrderId { get; set; }

    public Order Order { get; set; }

   // public List<IProductOption<object>>? ProductOptions { get; set; }

}
