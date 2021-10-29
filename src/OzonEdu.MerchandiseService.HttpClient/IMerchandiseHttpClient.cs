using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.HttpModels;

namespace OzonEdu.MerchandiseService.HttpClient
{
    public interface IMerchandiseHttpClient
    {
        Task<MerchOrderResponse> OrderMerch(long employeeId, MerchOrderViewModel merchOrderViewModel, CancellationToken token);
        Task<IssuedMerchInfoResponse> GetIssuedMerchInfo(long employeeId, CancellationToken token);
    }
}