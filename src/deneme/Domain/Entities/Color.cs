using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Entities;
public class Color : Entity<Guid>
{
    public string ColorName { get; set; }
    public virtual ICollection<Product>? Products { get; set; }

    public Color()  
    {
        Id = Guid.NewGuid();
        Products = new HashSet<Product>();
    }

    public Color(string name)
       : this()
    {
        ColorName = name;
    }
}
