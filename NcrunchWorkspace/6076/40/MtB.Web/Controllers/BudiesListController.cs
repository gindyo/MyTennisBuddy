using Microsoft.AspNetCore.Mvc;
using MtB.BuddyList;
using MtB.BuddyList.Plugins;
using MtB.Web.WebModels;
using System.Linq;

namespace MtB.Web.Controllers
{
    [Route("api/[controller]")]
    public partial class BuddiesListController : Controller
    {
        public IListBuddies ListBuddies { get; }
        public IAddBuddies StoreBuddies { get; }
        public BuddiesListController(IListBuddies listBuddies, IAddBuddies storeBuddies)
        {
            ListBuddies = listBuddies;
            StoreBuddies = storeBuddies;
        }

        [HttpGet("[action]")]
        public JsonResult Buddies()
        {
            return Json(ListBuddies.All().Select(b=> (WebBuddy)b));
        }
        [HttpPost("[action]")]
        public ActionResult New([FromBody]WebBuddy buddy)
        {
            try
            {
                StoreBuddies.New(new NewBuddy(buddy));
            }
            catch (System.Exception)
            {
                return new BadRequestResult();

            }
            return new CreatedResult("", null);
        }
        [HttpPost("[action]")]
        public ActionResult Update([FromBody]WebBuddy buddy)
        {
            StoreBuddies.Update(buddy);
            return new CreatedResult("", null);
        }
    }
}