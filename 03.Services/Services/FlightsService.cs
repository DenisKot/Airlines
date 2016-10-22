namespace _03.Services.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using _01.Domain.Models;
    using _02.Data.Repositories;

    public class FlightsService
    {
        IRepository<Flight> flightRepository; 

        public FlightsService()
        {
            IRepositoryFacade facade = new RepositoryFacade();

            flightRepository = facade.GetRepository<Flight>();
        }

        public IList<FlightListEntity> GetList()
        {
            return this.flightRepository.GetAll().Select(f => new FlightListEntity
            {
                Id = f.Id,
                CountryFrom = f.AirportFrom.Country.Name,
                AirportFrom = f.AirportFrom.Name,
                CountryTo = f.AirportTo.Country.Name,
                AirportTo = f.AirportTo.Name,
                LeavingTime = f.LeavingTime,
                Arrives = f.Arrives,
                Name = f.Name,
                Coast = f.Coast
            }).ToList();
        }

        public void Insert()
        {
            
        }
    }
}