using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Gift : Entity<Guid>
{

    public Guid CustomizationId { get; set; }
    public string Subject { get; set; }

    public string Message { get; set; }

    public Customization Customization { get; set; }
}
