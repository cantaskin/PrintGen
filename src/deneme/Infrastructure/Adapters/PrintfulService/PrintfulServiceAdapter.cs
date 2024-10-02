using Application.Features.Orders.Commands.Create;
using Application.Services.Orders;
using Application.Services.PrintfulService;
using Application.Services.Repositories;
using AutoMapper;
using Domain.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MimeKit.Cryptography;
using Newtonsoft.Json.Linq;
using NArchitecture.Core.Security.JWT;
using Newtonsoft.Json;
using MailKit.Search;
using Nest;

namespace Infrastructure.Adapters.PrintfulService
{
    public class PrintfulServiceAdapter : PrintfulServiceBase
    {
        private readonly HttpClient _httpClient;
        private readonly string accessToken;
        private readonly IOrderService _orderService;
        private readonly string _urlBase;
        private readonly string _storeId;

        public PrintfulServiceAdapter(IConfiguration configuration,IOrderService orderService)
        {
            _orderService = orderService;
            _httpClient = new HttpClient();
            _urlBase = configuration["Url:UrlBase"];
            _storeId = configuration["PrintfulAccount:StoreId"];
            accessToken = configuration["PrintfulAccount:Key"];
        }

        public async Task<string> GetAsync(string requestUrl,string key = null)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.GetAsync(requestUrl);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorContent}");
            }

            var content = await response.Content.ReadAsStringAsync();
            return ExtractContent(ModifyResponseContent(content),key);
        }

        public override async Task<string> CreateOrderAsync(Guid OrderId)
        {
            var requestUrl = "https://api.printful.com/v2/orders";

            // Get the order details
            Order? order = await _orderService.GetAsync(o => o.Id == OrderId);
            if (order == null)
            {
                throw new Exception($"Order with ID {OrderId} not found.");
            }

            // Convert order to DTO
            OrderDto orderDto = await GetOrderDto(order);
            
            // Send POST request with order DTO
            var responseContent = await SendPostRequestAsync(requestUrl, orderDto);
            
            // Update the order with the API response data
            order.OrderApiIp = ExtractContent(responseContent, "id");
            await _orderService.UpdateAsync(order);

            return responseContent;
        }

        public override async Task<string> CreateMockupAsync(MockupDto mockup)
        {
            var requestUrl = "https://api.printful.com/v2/mockup-tasks";

            // Send POST request with mockup DTO

            var response = await SendPostRequestAsync(requestUrl, mockup);
            return ExtractContent(ModifyResponseContent(response), null);
        }

        private async Task<string> SendPostRequestAsync<T>(string requestUrl, T contentObject)
        {
            // Set up authorization header
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            // Set X-PF-Store-Id header if storeId is provided
            if (!string.IsNullOrEmpty(_storeId))
            {
                _httpClient.DefaultRequestHeaders.Add("X-PF-Store-Id", _storeId);
            }

            try
            {
                // Serialize content object to JSON
                var jsonData = JsonConvert.SerializeObject(contentObject, Formatting.Indented); // Indented formatting for readability
                Console.WriteLine("Serialized JSON Data: " + jsonData); // Log JSON data for debugging
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                // Send POST request
                var response = await _httpClient.PostAsync(requestUrl, content);

                // Handle response
                if (!response.IsSuccessStatusCode)
                {
                    // Read the response content for more details
                    var errorContent = await response.Content.ReadAsStringAsync();
                    var errorMessage = $"Failed to create request. Status Code: {response.StatusCode}. " +
                                       $"Error Content: {errorContent}. Request URL: {requestUrl}. ";
                    throw new HttpRequestException(errorMessage);
                }

                // Parse and return the successful response content
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException httpEx)
            {
                // Log the detailed HTTP request exception with inner details
                Console.WriteLine($"HTTP Request failed: {httpEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                // Log general exceptions
                Console.WriteLine($"An error occurred while processing the request: {ex.Message}");
                throw;
            }
        }


        public override async Task<string> GetMockupAsync(string MockupId)
        {
            var requestUrl = $"https://api.printful.com/v2/mockup-tasks?id={MockupId}";
            var response = await GetAsync(requestUrl);
            return ExtractContent(ModifyResponseContent(response),null);
        }

        public override Task<string> GetOrderAsync(Guid OrderId)
        {
            throw new NotImplementedException();
        }

        public override async Task<string> CreateShippingRateAsync(ShippingRateDto _shippingRateDto)
        {
           var requestUrl = "https://api.printful.com/v2/shipping-rates";
           var response = await SendPostRequestAsync(requestUrl,_shippingRateDto);
           return ExtractContent(ModifyResponseContent(response), null);
        }


        private async Task<OrderDto> GetOrderDto(Order order)
        {
            

            Address? address = await _orderService.GetOrderAddressAsync(order);
            
            if (address == null)
                throw new Exception("There is no such address");

            List<OrderItem>? orderItems = await _orderService.GetOrderOrderItemsAsync(order.Id);
            
            if (orderItems.Count == 0)
                throw new Exception("Doesn't have order items");
            
            RetailCost? retailCost = await _orderService.GetRetailCostAsync(order);

             return OrderDto.ConvertToDto(order, address, orderItems, retailCost);
        }

        private string ExtractContent(string content,string Key)
        {
            if (Key == null)
            {
                return content;
            }
            var json = JObject.Parse(content);

            var data = json["data"] as JObject;
            if (data == null)
                throw new Exception("JSON'da 'data' alanı bulunamadı.");

            var Value = data[Key]?.ToString();
            
            return Value;
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
