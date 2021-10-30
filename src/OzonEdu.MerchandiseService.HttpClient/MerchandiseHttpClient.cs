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
        
        public async Task<MerchOrderResponse> OrderMerch(long employeeId, OrderMerchRequest orderMerchRequest, CancellationToken token)
        {
            var requestBody = JsonSerializer.Serialize(orderMerchRequest);
            var requestContent = new StringContent(requestBody, Encoding.UTF8, requestBody);
            
            using var response = await _httpClient.PostAsync("v1/api/Merchandise/OrderMerch", requestContent, token);
            
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<MerchOrderResponse>(body);
        }

        public async Task<IssuedMerchInfoResponse> GetIssuedMerchInfo(GetIssuedMerchRequest getIssuedMerchRequest, CancellationToken token)
        {
            var requestBody = JsonSerializer.Serialize(getIssuedMerchRequest);
            var requestContent = new StringContent(requestBody, Encoding.UTF8, requestBody);
            
            using var response = await _httpClient.PostAsync("v1/api/Merchandise/GetIssuedMerchInfo", requestContent, token);
            
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<IssuedMerchInfoResponse>(body);
        }
    }
}