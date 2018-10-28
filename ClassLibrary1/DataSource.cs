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
        private List<Ticket> tickets;
        public DataSource(AirportContext airportContext)
        {
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
                    new Plane { Name = "qwe", TimeSpan = 3, ReleaseDate = DateTime.Now},
                    new Plane { Name = "rty", TimeSpan = 4, ReleaseDate = DateTime.Now},
                    new Plane { Name = "zxc", TimeSpan = 5, ReleaseDate = DateTime.Now}
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
                    new Crew { Aviators = new List<Aviator> { aviators[0]}, Stewardesses = new List<Stewardess> { stewardesse_s[0]} },
                    new Crew { Aviators = new List<Aviator> { aviators[1]}, Stewardesses = new List<Stewardess> { stewardesse_s[1]} },
                    new Crew { Aviators = new List<Aviator> { aviators[2]}, Stewardesses = new List<Stewardess> { stewardesse_s[2]} }
                };
                airportContext.Crews.AddRange(crews);

                List<Flight> flights = new List<Flight>
                {
                    new Flight { Destination = "nulL", Tickets = new List<Ticket>{ tickets[0] }, ArrivalTime = DateTime.MinValue, PointOfDeparture = "Texas", TimeOfDeparture = DateTime.Now},
                    new Flight { Destination = "Null", Tickets = new List<Ticket>{ tickets[1] }, ArrivalTime = DateTime.MinValue, PointOfDeparture = "New Mexico", TimeOfDeparture = DateTime.Now},
                    new Flight { Destination = "nUll", Tickets = new List<Ticket>{ tickets[2] }, ArrivalTime = DateTime.MinValue, PointOfDeparture = "Los Santos", TimeOfDeparture = DateTime.Now}
                };
                airportContext.Flights.AddRange(flights);

                tickets = new List<Ticket>
                {
                    new Ticket { Price = 1000, FlightObj = flights[0]},
                    new Ticket { Price = 2000, FlightObj = flights[1]},
                    new Ticket { Price = 3000, FlightObj = flights[2]}
                };
                airportContext.Tickets.AddRange(tickets);

                List<TypePlane> typesPlane = new List<TypePlane>
                {
                    new TypePlane { CarryingCapacity = 1000, CountOfSeats = 60, ModelOfPlane = "suck"},
                    new TypePlane { CarryingCapacity = 1200, CountOfSeats = 80, ModelOfPlane = "my"},
                    new TypePlane { CarryingCapacity = 1500, CountOfSeats = 100, ModelOfPlane = "dick"}
                };
                airportContext.TypesPlane.AddRange(typesPlane);

                List<Departure> departures = new List<Departure>
                {
                    new Departure { FlightObj = flights[0], PlaneObj = planes[0], CrewObj = crews[0], TimeOfDeparture = 3},
                    new Departure { FlightObj = flights[1], PlaneObj = planes[1], CrewObj = crews[1], TimeOfDeparture = 4},
                    new Departure { FlightObj = flights[2], PlaneObj = planes[2], CrewObj = crews[2], TimeOfDeparture = 5}
                };
                airportContext.Departures.AddRange(departures);

                airportContext.SaveChanges();
            }
        }
    }
}