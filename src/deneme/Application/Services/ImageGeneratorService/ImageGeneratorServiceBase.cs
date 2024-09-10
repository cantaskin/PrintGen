using Microsoft.AspNetCore.Http;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Application.Services.ImageService;
using Application.Services.CustomizedImages;
using Application.Services.ImageGeneratorService;
using Application.Services.ImageService;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ImageGeneratorService;
public abstract class ImageGeneratorServiceBase
{
    protected readonly ImageServiceBase ImageServiceAdapter;
    public ImageGeneratorServiceBase(ImageServiceBase imageServiceAdapter)
    {
        ImageServiceAdapter = imageServiceAdapter;
    }
    public abstract Task<string> CreateAsync(string prompt);
    public abstract Task<string> RemoveBackgroundAsync(string url);

    public async Task<string> UploadImage(HttpResponseMessage response)
    {
        var responseData = await response.Content.ReadAsByteArrayAsync();
        var guid = Guid.NewGuid();
        var fileName = $"{guid}.png";

        using (var stream = new MemoryStream(responseData))
        {
            var formFile = new FormFile(stream, 0, responseData.Length, "image", fileName)
            {
                Headers = new HeaderDictionary(), ContentType = "image/png"
            };
            return await ImageServiceAdapter.UploadAsync(formFile);
        }
    }
}
