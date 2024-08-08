using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class CustomizedProduct : Entity<Guid>
{
    
    public Guid ProductId { get; set; }
    public Guid UserId { get; set; }
    public float Price { get; set; }//crudlara price eklemesi yap.
    public bool IsPublished { get; set; }
    public ICollection<OrderDetail> OrderDetails { get; set; }
    public virtual Product Product { get; set; }
    public virtual User User { get; set; }

}