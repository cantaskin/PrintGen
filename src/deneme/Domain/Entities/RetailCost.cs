using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class RetailCost : Entity<Guid>
{
    public string Currency { get; set; }

    public string Discount { get; set; }

    public string Shipping {  get; set; }

    public string Tax { get; set; }

    public Guid OrderId { get; set; }
    public Order Order { get; set; }
}
