using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OzonEdu.MerchandiseService.HttpModels;

namespace OzonEdu.MerchandiseService.Controllers
{
    [ApiController]
    [Route("v1/api/Merchandise")]
    public class MerchandiseController : ControllerBase
    {
        [HttpPost("OrderMerch")]
        public async Task<ActionResult<MerchOrderResponse>> OrderMerch(OrderMerchRequest orderMerchRequest, CancellationToken token)
        {
            return Ok();
        }
        
        [HttpPost("GetIssuedMerchInfo")]
        public async Task<ActionResult<IssuedMerchInfoResponse>> GetIssuedMerchInfo(GetIssuedMerchRequest getIssuedMerchRequest, CancellationToken token)
        {
            return Ok();
        }
    }
}