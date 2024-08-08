using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Product : Entity<Guid>
{
    public string ProductName { get; set; }
    public Guid CategoryId { get; set; }
    public Guid ColorId { get; set; }
    public float Price { get; set; }

    //public int Stock {get; set;} stok yapacak mıyız?
    public virtual Color Color { get; set; }
    public virtual Category Category { get; set; }
    public virtual ICollection<PrintArea> PrintArea { get; set; }
    public virtual ICollection<ProductImage> ProductImage { get; set; }

    public virtual ICollection<CustomizedProduct>? CustomizedProducts { get; set; }

    public Product()
    {
        Id = Guid.NewGuid();
        ProductImage = new HashSet<ProductImage>();
        PrintArea = new HashSet<PrintArea>();
    }

    public Product(string name, Guid categoryId, Guid colorId, Guid productImageId,float price) : this()
    {
        ProductName = name;
        CategoryId = categoryId;
        ColorId = colorId;
        Price = price;
    }
}
