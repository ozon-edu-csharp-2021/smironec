using System;
using System.Threading.Tasks;
using Grpc.Core;
using OzonEdu.MerchandiseService.Grpc;

namespace OzonEdu.MerchandiseService.GrpsServices
{
    public class MerchandiseGrpcService : MerchandiseServiceGrpc.MerchandiseServiceGrpcBase
    {
        public override Task<OrderMerchResponse> OrderMerch(OrderMerchRequest request, ServerCallContext context)
        {
            return Task.FromResult(new OrderMerchResponse());

        }

        public override Task<GetIssuedMerchInfoResponse> GetIssuedMerchInfo(GetIssuedMerchInfoRequest request, ServerCallContext context)
        {
            return Task.FromResult(new GetIssuedMerchInfoResponse());
        }
    }
}