using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class PackingSlip : Entity<Guid>
{
    public string Email { get; set; }

    public string Phone { get; set; }

    public string Message { get; set; }


    public string LogoUrl { get; set; }

    public string StoreName { get; set; }


    public List<Customization> Customizations { get; set; }

    public PackingSlip()
    {
        Id = Guid.NewGuid();
    }
}
