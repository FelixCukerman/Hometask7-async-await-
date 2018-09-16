using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using HometaskEntity.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace HometaskEntity.DAL
{
    public class DataSource
    {
        public DataSource(AirportContext airportContext)
        {
            airportContext.Database.EnsureCreated();

            if(!(airportContext.Aviators.Any(p => p.Name == "Alex" && p.Surname == "Harper" && p.Experience == 3 && p.DateOfBirthday == DateTime.MinValue)))
            {
                List<Aviator> aviators = new List<Aviator>
                {
                    new Aviator { Name = "Alex", Surname = "Harper", Experience = 3, DateOfBirthday = DateTime.MinValue},
                    new Aviator { Name = "Qwer", Surname = "Tiger", Experience = 2, DateOfBirthday = DateTime.Now},
                    new Aviator { Name = "Chery", Surname = "Bim", Experience = 1, DateOfBirthday = DateTime.MaxValue}
                };
                airportContext.Aviators.AddRange(aviators);

                List<Plane> planes = new List<Plane>
                {
                    new Plane { Name = "qwe", TimeSpan = 3, Type = "A", ReleaseDate = DateTime.Now},
                    new Plane { Name = "rty", TimeSpan = 4, Type = "B", ReleaseDate = DateTime.Now},
                    new Plane { Name = "zxc", TimeSpan = 5, Type = "C", ReleaseDate = DateTime.Now}
                };
                airportContext.Planes.AddRange(planes);

                List<Stewardess> stewardesse_s = new List<Stewardess>
                {
                    new Stewardess { Name = "Anna", Surname = "Kasparova", DateOfBirthday = DateTime.MinValue},
                    new Stewardess { Name = "Zany", Surname = "Jimova", DateOfBirthday = DateTime.MinValue},
                    new Stewardess { Name = "Sara", Surname = "Binomy", DateOfBirthday = DateTime.MinValue}
                };
                airportContext.Stewardesses.AddRange(stewardesse_s);

                List<Crew> crews = new List<Crew>
                {
                    new Crew { aviator = aviators[0], stewardesses = stewardesse_s},
                    new Crew { aviator = aviators[1], stewardesses = stewardesse_s},
                    new Crew { aviator = aviators[2], stewardesses = stewardesse_s}
                };
                airportContext.Crews.AddRange(crews);

                List<Ticket> tickets = new List<Ticket>
                {
                    new Ticket { Price = 1000, FlightNumber = 101},
                    new Ticket { Price = 2000, FlightNumber = 102},
                    new Ticket { Price = 3000, FlightNumber = 103}
                };
                airportContext.Tickets.AddRange(tickets);

                List<Flight> flights = new List<Flight>
                {
                    new Flight { Destination = "nulL", TicketId = tickets[0].Id, ArrivalTime = DateTime.MinValue, PointOfDeparture = "Texas", TimeOfDeparture = DateTime.Now},
                    new Flight { Destination = "Null", TicketId = tickets[1].Id, ArrivalTime = DateTime.MinValue, PointOfDeparture = "New Mexico", TimeOfDeparture = DateTime.Now},
                    new Flight { Destination = "nUll", TicketId = tickets[2].Id, ArrivalTime = DateTime.MinValue, PointOfDeparture = "Los Santos", TimeOfDeparture = DateTime.Now}
                };
                airportContext.Flights.AddRange(flights);



                List<TypePlane> typesPlane = new List<TypePlane>
                {
                    new TypePlane { CarryingCapacity = 1000, CountOfSeats = 60, ModelOfPlane = "suck"},
                    new TypePlane { CarryingCapacity = 1200, CountOfSeats = 80, ModelOfPlane = "my"},
                    new TypePlane { CarryingCapacity = 1500, CountOfSeats = 100, ModelOfPlane = "dick"}
                };
                airportContext.TypesPlane.AddRange(typesPlane);

                List<Departure> departures = new List<Departure>
                {
                    new Departure { FlightNumber = 111, PlaneObj = planes[0], CrewObj = crews[0], TimeOfDeparture = 3},
                    new Departure { FlightNumber = 222, PlaneObj = planes[1], CrewObj = crews[1], TimeOfDeparture = 4},
                    new Departure { FlightNumber = 333, PlaneObj = planes[2], CrewObj = crews[2], TimeOfDeparture = 5}
                };
                airportContext.Departures.AddRange(departures);

                airportContext.SaveChanges();
            }
        }
    }
}