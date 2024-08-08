using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductImages.Queries.GetListByProductId;
public class GetListByProductIdProductImageListItemDto
{
    public Guid Id { get; set; }
    public string ProductName { get; set; }
    public string CategoryName { get; set; }
    public string ColorName { get; set; }
    public string ImageUrl { get; set; }
    public Guid ProductId { get; set; }
}
