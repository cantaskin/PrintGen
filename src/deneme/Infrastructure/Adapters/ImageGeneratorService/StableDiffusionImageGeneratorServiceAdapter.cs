﻿using Application.Services.CustomizedImages;
using Application.Services.ImageGeneratorService;
using Application.Services.ImageService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Adapters.ImageGeneratorService
{
    public class StableDiffusionImageGeneratorServiceAdapter : ImageGeneratorServiceBase
    {
        private readonly string apikey;
        private readonly string model;
        private readonly string baseurl = "https://api.stability.ai/v2beta/stable-image";

        public StableDiffusionImageGeneratorServiceAdapter(ImageServiceBase _ImageServiceAdapter, IConfiguration configuration) : base(_ImageServiceAdapter)
        {
            apikey = configuration["StableDiffusionAccount:Key"];
            model = configuration["StableDiffusionAccount:Model"];
        }

        public override async Task<string> CreateAsync(string prompt)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apikey);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("image/*"));

                var content = new MultipartFormDataContent();

                // Form verilerini ekleme
                var promptContent = new StringContent(prompt);
                promptContent.Headers.ContentDisposition =
                    new ContentDispositionHeaderValue("form-data") { Name = "\"prompt\"" };
                content.Add(promptContent);


                try
                {
                    var response = await client.PostAsync($"{baseurl}/generate/{model}", content);

                    if (response.IsSuccessStatusCode)
                    {
                       return await UploadImage(response);
                    }
                    else
                    {
                        var errorContent = await response.Content.ReadAsStringAsync();
                        throw new Exception($"Error: {errorContent}");
                    }
                }
                catch (Exception ex)
                {
                    var formData = new StringBuilder();
                    foreach (var part in content)
                    {
                        formData.AppendLine(part.Headers.ContentDisposition.ToString());
                    }

                    throw new Exception($"Error: {ex.Message}\nContent: {formData}", ex);
                }
            }
        }

        public override async Task<string> RemoveBackgroundAsync(string url)
        {

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apikey);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("image/*"));

                var content = new MultipartFormDataContent();

                byte[] imageBytes = await client.GetByteArrayAsync(url);

                string filename = Path.GetFileName(new Uri(url).LocalPath);

                var imageContent = new ByteArrayContent(imageBytes);
                imageContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "\"image\"",
                    FileName = $"\"{filename}\""
                };
                imageContent.Headers.ContentType = new MediaTypeHeaderValue("image/png");

                content.Add(imageContent);

                var outputFormatContent = new StringContent("png");
                outputFormatContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "\"output_format\""
                };
                content.Add(outputFormatContent);

                try
                {
                    var response = await client.PostAsync($"{baseurl}/edit/remove-background", content);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsByteArrayAsync();
                        var guid = Guid.NewGuid();
                        var fileName = $"{guid}.png";

                        using (var stream = new MemoryStream(responseData))
                        {
                            var formFile = new FormFile(stream, 0, responseData.Length, "image", fileName)
                            {
                                Headers = new HeaderDictionary(),
                                ContentType = "image/png"
                            };

                            return await ImageServiceAdapter.UploadAsync(formFile);
                        }
                    }
                    else
                    {
                        var errorContent = await response.Content.ReadAsStringAsync();
                        throw new Exception($"Error: {errorContent}");
                    }
                }
                catch (Exception ex)
                {
                    var formData = new StringBuilder();
                    foreach (var part in content)
                    {
                        formData.AppendLine(part.Headers.ContentDisposition.ToString());
                    }
                    throw new Exception($"Error: {ex.Message}\nContent: {formData}", ex);
                }
            }
        }
    }

    //public async Task<string> UpscalingAsync(string url, string prompt)
    //{

    //    using (var client = new HttpClient())
    //    {
    //        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apikey);
    //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("image/*"));

    //        var content = new MultipartFormDataContent();

    //        // Form verilerini ekleme
    //        var promptContent = new StringContent(prompt);
    //        promptContent.Headers.ContentDisposition =
    //            new ContentDispositionHeaderValue("form-data") { Name = "\"prompt\"" };
    //        content.Add(promptContent);

    //        byte[] imageBytes = await client.GetByteArrayAsync(url);

    //        string filename = Path.GetFileName(new Uri(url).LocalPath);

    //        var imageContent = new ByteArrayContent(imageBytes);
    //        imageContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
    //        {
    //            Name = "\"image\"",
    //            FileName = $"\"{filename}\""
    //        };
    //        //buraya contente belki dosyanın png türünde olduğuyla ilgili bir kod eklenebilir. Testte hataya göre bak.
    //        content.Add(imageContent);

    //        try
    //        {
    //            var response = await client.PostAsync($"{baseurl}/upscale/conservative", content);

    //            if (response.IsSuccessStatusCode)
    //            {
    //                var responseData = await response.Content.ReadAsByteArrayAsync();
    //                var guid = Guid.NewGuid();
    //                var fileName = $"{guid}.png";

    //                using (var stream = new MemoryStream(responseData))
    //                {
    //                    var formFile = new FormFile(stream, 0, responseData.Length, "image", fileName)
    //                    {
    //                        Headers = new HeaderDictionary(),
    //                        ContentType = "image/png"
    //                    };

    //                    return await ImageServiceAdapter.UpdateAsync(formFile, url);
    //                }
    //            }
    //            else
    //            {
    //                var errorContent = await response.Content.ReadAsStringAsync();
    //                throw new Exception($"Error: {errorContent}");
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            var formData = new StringBuilder();
    //            foreach (var part in content)
    //            {
    //                formData.AppendLine(part.Headers.ContentDisposition.ToString());
    //            }

    //            throw new Exception($"Error: {ex.Message}\nContent: {formData}", ex);
    //        }
    //    }
    //}

}
