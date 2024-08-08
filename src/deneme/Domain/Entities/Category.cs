using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Category : Entity<Guid>
{
    public string CategoryName { get; set; }
    public virtual ICollection<Product>? Products { get; set; }

    public Category()
    {
        Products = new HashSet<Product>();
        Id = Guid.NewGuid();
    }

    public Category(string name) : this()
    {
        CategoryName = name;
    }
}
