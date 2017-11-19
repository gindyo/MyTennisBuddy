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
        public BuddiesListController(IListBuddies listBuddies)
        {
            ListBuddies = listBuddies;
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
                ListBuddies.New(new NewBuddy(buddy));
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
            ListBuddies.Update(buddy);
            return new CreatedResult("", null);
        }
    }
}