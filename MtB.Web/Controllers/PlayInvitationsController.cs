using System;
using System.Linq;
using Core.PlayInvitations;
using Microsoft.AspNetCore.Mvc;
using Web.WebModels;

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
            var invitatiots = _playInvitationsProvider.Inbound().Select(i => new WebPlayInvitation(i));
            return new JsonResult(invitatiots);
        }

        [HttpPost("")]
        public JsonResult Create([FromBody] WebPlayInvitation invitation)
        {
            return new JsonResult(BaseAddress + _playInvitationsStore.Create(invitation));
        }
    }
}