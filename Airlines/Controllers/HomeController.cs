using System.Web.Mvc;

namespace Airlines.Controllers
{
    using _03.Services.Services;

    public class HomeController : Controller
    {
        private readonly FlightsService flightsService;

        public HomeController()
        {
            this.flightsService = new FlightsService();
        }

        public ActionResult Index()
        {
            var list = this.flightsService.GetList();
            ViewBag.list = list;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}