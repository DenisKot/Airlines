namespace _03.Services.Services
{
    using System;
    using _00.Common;
    using _01.Domain.Models;

    public class HtmlFormer
    {
        public string Form(FlightListEntity model, Ticket ticket)
        {
            return string.Format("<h2>Білет №{0}</h2>" +
                                 "<h2> Name {1}</h2>" +
                                 "<h3> Відпралення: {2}</h3>" +
                                 "<h3> Прибуття: {3}</h3>" +
                                 "<h3> Виліт з: {4}</h3>" +
                                 "<h3> Прибуття до: {5}</h3>" +
                                 "<h3> Вартість: {6}</h3> ",
                                 ticket.Transaction,
                                 model.Name,
                                 DateTimeExpression.ToDayMonthYear(model.LeavingTime),
                                 DateTimeExpression.ToDayMonthYear(model.Arrives),
                                 model.AirportFrom + "(" + model.CountryFrom+")",
                                 model.AirportTo + "(" + model.CountryTo + ")",
                                 model.Coast);
        }
    }
}