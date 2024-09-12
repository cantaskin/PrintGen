using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class TemplateProduct : Entity<Guid>
{
    public int OrderCount { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }

}
