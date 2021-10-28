using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OzonEdu.MerchandiseService.HttpModels;

namespace OzonEdu.MerchandiseService.Controllers
{
    [ApiController]
    [Route("v1/api")]
    public class MerchandiseController : ControllerBase
    {
        [HttpPost("/employee/{employeeId}/merch")]
        public Task<ActionResult<MerchOrderResponse>> OrderMerch(long employeeId, MerchOrderViewModel merchOrderViewModel, CancellationToken token)
        {
            throw new NotImplementedException();
        }
        
        [HttpGet("/employee/{employeeId}/merch/issued")]
        public Task<ActionResult<IssuedMerchInfoResponse>> GetIssuedMerchInfo(long employeeId, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
    
    
}