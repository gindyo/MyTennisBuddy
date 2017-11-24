using System;
using Core.PlayInvitations;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class PlayInvitationsController : Controller
    {
        private const string BaseAddress = "playRequests/";
        private readonly IProvidePlayInvitations _playInvitationsProvider;
        private readonly IStorePlayInvitations _playInvitationsStore;

        public PlayInvitationsController(IProvidePlayInvitations playInvitationsProvider, IStorePlayInvitations playInvitationsStore)
        {
            _playInvitationsProvider = playInvitationsProvider;
            _playInvitationsStore = playInvitationsStore;
        }

        [HttpGet("")]
        public JsonResult All()
        {
            return new JsonResult(_playInvitationsProvider.Inbound());
        }

        [HttpPost("")]
        public JsonResult Create([FromBody] PlayInvitation invitation)
        {
            return new JsonResult(BaseAddress + _playInvitationsStore.Create());
        }
    }
}