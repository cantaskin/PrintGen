using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Order : Entity<Guid>
{

    public Guid AddressId { get; set; }

    public Guid RetailCostId { get; set; }
    public Guid? CustomizationId { get; set; }
    public string? Shipping { get; set; }

    public List<OrderItem> OrderItems { get; set; }

}
