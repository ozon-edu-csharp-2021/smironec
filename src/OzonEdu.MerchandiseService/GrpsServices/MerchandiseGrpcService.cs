using System;
using System.Threading.Tasks;
using Grpc.Core;
using OzonEdu.MerchandiseService.Grpc;

namespace OzonEdu.MerchandiseService.GrpsServices
{
    public class MerchandiseGrpcService : MerchandiseServiceGrpc.MerchandiseServiceGrpcBase
    {
        public override async Task<OrderMerchResponse> OrderMerch(OrderMerchRequest request, ServerCallContext context)
        {
            return new OrderMerchResponse();

        }

        public override async Task<GetIssuedMerchInfoResponse> GetIssuedMerchInfo(GetIssuedMerchInfoRequest request, ServerCallContext context)
        {
            return new GetIssuedMerchInfoResponse();
        }
    }
}