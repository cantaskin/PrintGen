using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace Infrastructure.Adapters.PrintfulService
{
    public class PrintfulServiceAdapter
    {
        private readonly HttpClient _httpClient;
        private readonly string accessToken = "4sJCPLEKrXzHHu1ltYUzLEwjYUgkCS38CoeNpv7c";
        private readonly string _urlBase;

        public PrintfulServiceAdapter(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _urlBase = configuration["Url:UrlBase"];
        }

        public async Task<string> GetAsync(string requestUrl)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.GetAsync(requestUrl);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorContent}");
            }

            var content = await response.Content.ReadAsStringAsync();
            return ModifyResponseContent(content);
        }

        private string ModifyResponseContent(string content)
        {
            var json = JObject.Parse(content);

            ReplaceUrls(json);

            return json.ToString();
        }

        private void ReplaceUrls(JToken token)
        {
            if (token.Type == JTokenType.Object)
            {
                var obj = (JObject)token;
                foreach (var property in obj.Properties())
                {
                    ReplaceUrls(property.Value);
                }
            }
            else if (token.Type == JTokenType.Array)
            {
                foreach (var item in (JArray)token)
                {
                    ReplaceUrls(item);
                }
            }
            else if (token.Type == JTokenType.String)
            {
                var str = token.ToString();
                if (str.Contains("https://api.printful.com/v2/"))
                {
                    var replacedStr = str.Replace("https://api.printful.com/v2/", _urlBase);
                    token.Replace(replacedStr);
                }
            }
        }


    }
}
