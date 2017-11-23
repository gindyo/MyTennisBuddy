using System;
using Core.PlayRequests;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class PlayRequestsController : Controller
    {
        private const string BaseAddress = "playRequests/";
        private readonly IProvidePlayRequests _playRequestsProvider;
        private readonly IStorePlayRequests _playRequestsStore;

        public PlayRequestsController(IProvidePlayRequests playRequestsProvider, IStorePlayRequests playRequestsStore)
        {
            _playRequestsProvider = playRequestsProvider;
            _playRequestsStore = playRequestsStore;
        }

        [HttpGet("")]
        public JsonResult All()
        {
            return new JsonResult(_playRequestsProvider.Inbound());
        }

        [HttpPost("")]
        public JsonResult Create([FromBody] PlayRequest request)
        {
            return new JsonResult(BaseAddress + _playRequestsStore.Create());
        }
    }
}