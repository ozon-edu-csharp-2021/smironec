using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.HttpModels;

namespace OzonEdu.MerchandiseService.HttpClient
{
    public interface IMerchandiseHttpClient
    {
        Task<V1MerchOrderResponse> OrderMerch(V1OrderMerchRequest orderMerchRequest, CancellationToken token);
        Task<V1IssuedMerchInfoResponse> GetIssuedMerchInfo(V1GetIssuedMerchRequest getIssuedMerchRequest, CancellationToken token);
    }
}