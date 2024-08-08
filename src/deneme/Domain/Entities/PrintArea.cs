using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class PrintArea : Entity<Guid>
{
    public Guid PrintAreaNameId { get; set; }
    public Guid ProductId { get; set; }
    public Guid? CustomizedImageId { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public virtual PrintAreaName PrintAreaName { get; set; }
    public virtual CustomizedImage? CustomizedImage { get; set; }
    public virtual Product Product { get; set; }

    public PrintArea() 
    {
        Id = Guid.NewGuid();
    }

    public PrintArea(Guid printAreaNameId, Guid productId, Guid customizedImageId, int x, int y) : this()
    {
        PrintAreaNameId = printAreaNameId;
        ProductId = productId;
        CustomizedImageId = customizedImageId;
        X = x;
        Y = y;
    }
}
