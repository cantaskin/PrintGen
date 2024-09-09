using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Address : Entity<Guid>
{
    public string Name { get; set; }
    public string Company { get; set; }

    public string Address1 { get; set; }

    public string Address2 { get; set; }

    public string City { get; set; }

    public string StateCode { get; set; }

    public string StateName { get; set; }

    public string CountryName { get; set; }

    public string CountryCode { get; set; }

    public string Zip { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }

    public string? TaxNumber { get; set; }

    public List<Order> Orders { get; set; }

    public Address()
    {
        Id = Guid.NewGuid();
    }
}
