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

        public ActionResult Index(string from, string to)
        {
            var list = this.flightsService.GetList(from, to);
            ViewBag.list = list;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Компанія специфікуться на перевезенні пасажирів по всьому світові.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Контактна сторінка";

            return View();
        }
    }
}