using System.Collections.Generic;
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
            
            using var response = await _httpClient.PostAsync($"v1/api/epmloyee/{employeeId}/merch", requestContent, token);
            
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<MerchOrderResponse>(body);
        }

        public async Task<IssuedMerchInfoResponse> GetIssuedMerchInfo(long employeeId, CancellationToken token)
        {
            using var response = await _httpClient.GetAsync($"v1/api/employee/{employeeId}/merch/issued", token);
            
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<IssuedMerchInfoResponse>(body);
        }
    }
}