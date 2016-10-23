using System.Web.Mvc;

namespace Airlines.Controllers
{
    public class BuyController : Controller
    {
        // GET: Buy
        public ActionResult Ticket(string userName, string email, string card, string secret)
        {
            return View();
        }
    }
}