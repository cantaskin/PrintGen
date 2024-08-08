using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Address : Entity<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
    public ICollection<Order> Orders { get; set; }
}
