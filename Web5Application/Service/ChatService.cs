using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Web5Application.Service
{
    public class ChatService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "https://api.openai.com/v1/engines/davinci/completions"; // 示例 URL
        private readonly string _apiKey = "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";

        public ChatService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetResponse(string userInput)
        {
            var requestData = new
            {
                prompt = userInput,
                max_tokens = 100 // 示例参数
            };

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(_apiUrl),
                Content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json"),
                Headers =
            {
                { "Authorization", $"Bearer {_apiKey}" }
            }
            };

            try
            {
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return content; // 解析并返回响应
            }
            catch (HttpRequestException e)
            {
                // 适当的错误处理
                return $"Error: {e.Message}";
            }
        }
    }

}