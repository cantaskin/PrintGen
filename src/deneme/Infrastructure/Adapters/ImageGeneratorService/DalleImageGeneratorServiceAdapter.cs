using Application.Services.ImageGeneratorService;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using OpenAI_API;
using OpenAI_API.Images;
using CloudinaryDotNet;
using Microsoft.Extensions.Configuration;
using Application.Services.ImageService;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Net.Mime.MediaTypeNames;

namespace Infrastructure.Adapters.ImageGeneratorService;
public class DalleImageGeneratorServiceAdapter : ImageGeneratorServiceBase
{
    private readonly OpenAIAPI _openAIAPI;
    private readonly ImageServiceBase _imageServiceBase;

    public DalleImageGeneratorServiceAdapter(IConfiguration configuration, ImageServiceBase imageServiceBase)
    {
        _imageServiceBase = imageServiceBase;
        Account? account = configuration.GetSection("DalleAccount").Get<Account>();
        _openAIAPI = new OpenAIAPI(account.ApiKey);
    }
    public override async Task<string> CreateAsync(string prompt)
    {
        ImageGenerationRequest request =  new ImageGenerationRequest(prompt, OpenAI_API.Models.Model.DALLE3, ImageSize._1024,"standard");
        var result = await _openAIAPI.ImageGenerations.CreateImageAsync(request);
        return result.ToString();
           
    }

    
}
