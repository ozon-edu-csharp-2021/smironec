using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OzonEdu.MerchandiseService.HttpModels;

namespace OzonEdu.MerchandiseService.Controllers
{
    [ApiController]
    [Route("v1/api/merchandise")]
    public class MerchandiseController : ControllerBase
    {
        [HttpPost("order-merch")]
        public async Task<ActionResult<V1MerchOrderResponse>> OrderMerch(V1OrderMerchRequest orderMerchRequest, CancellationToken token)
        {
            return Ok();
        }
        
        [HttpPost("get-issued-merch-info")]
        public async Task<ActionResult<V1IssuedMerchInfoResponse>> GetIssuedMerchInfo(V1GetIssuedMerchRequest getIssuedMerchRequest, CancellationToken token)
        {
            return Ok();
        }
    }
}