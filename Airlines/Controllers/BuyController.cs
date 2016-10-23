using System.Web.Mvc;

namespace Airlines.Controllers
{
    using _03.Services.Services;

    public class BuyController : Controller
    {
        private readonly TicketService ticketService;

        private readonly FlightsService flightsService;

        private readonly HtmlFormer htmlFormer;

        private readonly SmtpService smtpService;

        public BuyController()
        {
            this.ticketService = new TicketService();
            this.flightsService = new FlightsService();
            this.htmlFormer = new HtmlFormer();
            this.smtpService = new SmtpService();
        }

        // GET: Buy
        public ActionResult Ticket(int id, string userName, string email, string card, string secret)
        {
            var ticket = this.ticketService.Create(id, email);
            var html = this.htmlFormer.Form(this.flightsService.Get(id), ticket);

            this.smtpService.Send(html, email);
            this.ViewBag.Html = html;

            return View();
        }
    }
}