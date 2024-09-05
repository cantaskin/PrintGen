using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Customization : Entity<Guid>
{
    public Guid? GiftId { get; set; }

   // public Gift? Gift { get; set; }

    public Guid PackingSlipId { get; set; } // = "" buraya hardcode değer gir ya da json dosyasından girilen id değerini ctor'da config'den çek.

    public Guid OrderId { get; set; }

    public Order Order { get; set; }

    //public PackingSlip PackingSlip { get; set; }
}
