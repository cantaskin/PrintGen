using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Adapters.PrintfulService;
public class PrintfulServiceAdapter
{
    private readonly HttpClient _httpClient;
    private readonly string accessToken = "4sJCPLEKrXzHHu1ltYUzLEwjYUgkCS38CoeNpv7c";

    public PrintfulServiceAdapter()
    {
        _httpClient = new HttpClient();

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

        return await response.Content.ReadAsStringAsync();
    }
}
