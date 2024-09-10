using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.PrintfulService;
public abstract class PrintfulServiceBase
{
    public abstract Task<string> CreateOrderAsync(Guid OrderId);
}
