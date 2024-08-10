using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class CustomizedImage : Entity<Guid>
{
    public string? ImageUrl { get; set; }
    public Guid? PromptId { get; set; }
    public Prompt? ImagePrompt { get; set; }

    public CustomizedImage()
    {
        Id = Guid.NewGuid();
    }

    public CustomizedImage(string ımageUrl, Guid promptId) : this()
    {
        ImageUrl = ımageUrl;
        PromptId = promptId;
    }
}
