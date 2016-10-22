namespace _01.Domain.Models
{
    using System;

    public class FlightListEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public decimal Coast { get; set; }
        
        public DateTime? LeavingTime { get; set; }
        
        public DateTime? Arrives { get; set; }

        public string AirportFrom { get; set; }

        public string CountryFrom { get; set; }

        public string AirportTo { get; set; }

        public string CountryTo { get; set; }
    }
}