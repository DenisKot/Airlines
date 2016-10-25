namespace _03.Services.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
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

        public IList<FlightListEntity> GetList(string from, string to)
        {
            //Expression<Func<Flight, bool>> exFrom = f => f.AirportFrom.Country.Name.Contains(from) || f.AirportFrom.Name.Contains(from);
            //Expression<Func<Flight, bool>> exTo = f => f.AirportTo.Country.Name.Contains(from) || f.AirportTo.Name.Contains(from);

            var query = this.flightRepository.GetAll().Select(f => new FlightListEntity
            {
                Id = f.Id,
                CountryFrom = f.AirportFrom.Country.Name,
                AirportFrom = f.AirportFrom.Name,
                CountryTo = f.AirportTo.Country.Name,
                AirportTo = f.AirportTo.Name,
                LeavingTime = f.LeavingTime,
                Arrives = f.Arrives,
                Name = f.AirportFrom.Name + " - " + f.AirportTo.Name,
                Coast = f.Coast
            });

            if (!string.IsNullOrWhiteSpace(from))
            {
                query = query.Where(f => f.AirportFrom.Contains(from) || f.CountryFrom.Contains(from));
            }
            if (!string.IsNullOrWhiteSpace(to))
            {
                query = query.Where(f => f.AirportTo.Contains(to) || f.CountryTo.Contains(to));
            }

            return query.ToList();
        }

        public FlightListEntity Get(int id)
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
                Name = f.AirportFrom.Name + " - " + f.AirportTo.Name,
                Coast = f.Coast
            }).FirstOrDefault(f => f.Id == id);
        }
    }
}