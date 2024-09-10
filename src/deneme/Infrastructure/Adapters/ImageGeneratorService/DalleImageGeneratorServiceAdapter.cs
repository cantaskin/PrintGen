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

    public DalleImageGeneratorServiceAdapter(IConfiguration configuration, ImageServiceBase imageServiceBase) : base(imageServiceBase)
    {
        Account? account = configuration.GetSection("DalleAccount").Get<Account>();
        _openAIAPI = new OpenAIAPI(account.ApiKey);
    }

    public override async Task<string> CreateAsync(string prompt)
    {
        ImageGenerationRequest request =
            new ImageGenerationRequest(prompt, OpenAI_API.Models.Model.DALLE3, ImageSize._1024, "hd");
        var result = await _openAIAPI.ImageGenerations.CreateImageAsync(request);
        var imageUrl = result.Data[0].Url;

        using (HttpClient client = new HttpClient())
        {

            var response = await client.GetAsync(imageUrl);

            if (response.IsSuccessStatusCode)
            {
                return await UploadImage(response);
            }
            else
            {
                throw new Exception("Image generation error");

            }
            //return result.ToString();

        }
    }

    public override Task<string> RemoveBackgroundAsync(string url)
    {
        throw new NotImplementedException();
    }
}
