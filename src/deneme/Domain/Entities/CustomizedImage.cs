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
    public Guid PrintAreaId { get; set; }
    public Guid PromptId { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public virtual PrintArea PrintArea { get; set; }
    public virtual Prompt ImagePrompt { get; set; }

    public CustomizedImage()
    {
        Id = Guid.NewGuid();
    }

    public CustomizedImage(string ımageUrl, Guid printAreaId, int x, int y, Guid promptId) : this()
    {
        ImageUrl = ımageUrl;
        PrintAreaId = printAreaId;
        PromptId = promptId;
        X = x;
        Y = y;
    }
}
