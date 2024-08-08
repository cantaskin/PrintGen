using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class ProductImage : Entity<Guid>
{
    public string ImageUrl { get; set; }
    public Guid ProductId { get; set; }
    public virtual Product Product { get; set; }

    public ProductImage() 
    {
        Id = Guid.NewGuid();
    }

    public ProductImage(string ımageUrl, Guid productId) : this()
    {
        ImageUrl = ımageUrl;
        ProductId = productId;
    }
}
