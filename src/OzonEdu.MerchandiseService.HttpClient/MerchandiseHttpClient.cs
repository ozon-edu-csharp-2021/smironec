using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.HttpModels;

namespace OzonEdu.MerchandiseService.HttpClient
{
    public class MerchandiseHttpClient : IMerchandiseHttpClient
    {
        private readonly System.Net.Http.HttpClient _httpClient;

        public MerchandiseHttpClient(System.Net.Http.HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<V1MerchOrderResponse> OrderMerch(V1OrderMerchRequest orderMerchRequest, CancellationToken token)
        {
            var requestBody = JsonSerializer.Serialize(orderMerchRequest);
            var requestContent = new StringContent(requestBody, Encoding.UTF8, requestBody);
            
            using var response = await _httpClient.PostAsync("v1/api/merchandise/order-merch", requestContent, token);
            
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<V1MerchOrderResponse>(body);
        }

        public async Task<V1IssuedMerchInfoResponse> GetIssuedMerchInfo(V1GetIssuedMerchRequest getIssuedMerchRequest, CancellationToken token)
        {
            var requestBody = JsonSerializer.Serialize(getIssuedMerchRequest);
            var requestContent = new StringContent(requestBody, Encoding.UTF8, requestBody);
            
            using var response = await _httpClient.PostAsync("v1/api/merchandise/get-issued-merch-info", requestContent, token);
            
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<V1IssuedMerchInfoResponse>(body);
        }
    }
}