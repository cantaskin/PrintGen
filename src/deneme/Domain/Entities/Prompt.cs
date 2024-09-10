using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Prompt : Entity<Guid>
{
    public string PromptString { get; set; }

    public Guid PromptCategoryId { get; set; }
    public List<CustomizedImage> Images { get; set; }
    public PromptCategory PromptCategory { get; set; }

    public Guid UserId { get; set; }

    public User User { get; set; }

    public Prompt() 
    {
        Id = Guid.NewGuid();
    }

}
