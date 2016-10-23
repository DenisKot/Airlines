namespace _03.Services.Services
{
    using System;
    using _01.Domain.Models;
    using _02.Data;
    using _02.Data.Repositories;

    public class TicketService
    {
        private readonly FlightsService flightsService;

        private readonly IRepository<Ticket> ticketRepository;

        public TicketService()
        {
            flightsService = new FlightsService();
            ticketRepository = new RepositoryFacade().GetRepository<Ticket>();
        }

        public Ticket Create(int flightId, string email)
        {
            var flight = this.flightsService.Get(flightId);
            var rand = new Random();
            var ticket = new Ticket
            {
                Transaction = rand.Next(100, 10000).ToString(),
                CreationDate = DateTime.Now,
                Details = flight.Name,
                Email = email
            };

            this.ticketRepository.Insert(ticket);
            this.ticketRepository.Save();

            return ticket;
        }
    }
}