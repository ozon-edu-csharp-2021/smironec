using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.HttpModels;

namespace OzonEdu.MerchandiseService.HttpClient
{
    public interface IMerchandiseHttpClient
    {
        Task<MerchOrderResponse> OrderMerch(long employeeId, OrderMerchRequest orderMerchRequest, CancellationToken token);
        Task<IssuedMerchInfoResponse> GetIssuedMerchInfo(GetIssuedMerchRequest getIssuedMerchRequest, CancellationToken token);
    }
}