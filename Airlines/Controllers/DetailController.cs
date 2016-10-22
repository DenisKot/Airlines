namespace Airlines.Controllers
{
    using System.Web.Mvc;
    using _03.Services.Services;

    public class DetailController : Controller
    {
        private readonly FlightsService flightsService;

        public DetailController()
        {
            this.flightsService = new FlightsService();
        }

        // GET: Detail
        public ActionResult Flight(int id)
        {
            var model = this.flightsService.Get(id);
            this.ViewBag.model = model;

            return View();
        }
    }
}