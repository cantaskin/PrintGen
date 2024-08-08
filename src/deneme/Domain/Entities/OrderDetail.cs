using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class OrderDetail : Entity<Guid>
{
    public Guid CustomizedProductId { get; set; }

    public Guid OrderId { get; set; }

    public float Price { get; set; }

    public int Quantity { get; set; }

    public int Discount { get; set; }
    public virtual CustomizedProduct CustomizedProduct { get; set; }
    public Order Order { get; set; }
}
