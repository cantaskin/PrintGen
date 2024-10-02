using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.PrintfulService;
public abstract class PrintfulServiceBase
{
    public abstract Task<string> CreateOrderAsync(Guid OrderId);

    public abstract Task<string> CreateMockupAsync(MockupDto mockup);

    public abstract Task<string> GetMockupAsync(string MockupId);
    public abstract Task<string> GetOrderAsync(Guid OrderId);

    public abstract Task<string> CreateShippingRateAsync(ShippingRateDto _shippingRateDto);
}
