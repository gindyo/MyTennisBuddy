using System;
using System.Linq;
using Core.BuddyList;
using Core.BuddyList.Entities;
using Microsoft.AspNetCore.Mvc;
using Web.WebModels;

namespace Web.Controllers
{
    [Route("api/Buddies")]
    public  class BuddiesListController : Controller
    {
        public IListBuddies ListBuddies { get; }
        public IAddBuddy AddBuddy { get; }

        public BuddiesListController(IListBuddies listBuddies, IAddBuddy addBuddy)
        {
            ListBuddies = listBuddies;
            AddBuddy = addBuddy;
        }


        [HttpGet("{id}")]
        public JsonResult Buddy(Guid id)
        {
            return Json(ListBuddies.Get(id));
        }
        [HttpGet("")]
        public JsonResult Buddies()
        {
            return Json(ListBuddies.All().Select(b=> (WebBuddy)b));
        }
        [HttpPost("")]
        public ActionResult New([FromBody]WebBuddy buddy)
        {
            try
            {
                AddBuddy.New(new NewBuddy(buddy));
            }
            catch (System.Exception)
            {
                return new BadRequestResult();

            }
            return new CreatedResult("", null);
        }

        [HttpPost("")]
        public ActionResult Update([FromBody]WebBuddy buddy)
        {
            AddBuddy.Update(buddy);
            return new CreatedResult("", null);
        }
    }
}