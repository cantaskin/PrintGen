using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Order : Entity<Guid>
{
    public int Number { get; set; }

    public Guid OrderTransportId { get; set; }

    public Guid UserId { get; set; } 

    public Guid AddressId { get; set; }

    public virtual User User { get; set; }

    public virtual Address Address { get; set; }

   public OrderTransport OrderTransport { get; set; }
    public ICollection<OrderDetail> OrderDetails { get; set; }
}
