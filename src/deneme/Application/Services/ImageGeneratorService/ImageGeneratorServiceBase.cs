using Microsoft.AspNetCore.Http;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ImageGeneratorService;
public abstract class ImageGeneratorServiceBase
{
    public abstract Task<string> CreateAsync(string prompt);
    public abstract Task<string> RemoveBackgroundAsync(string url);
}
