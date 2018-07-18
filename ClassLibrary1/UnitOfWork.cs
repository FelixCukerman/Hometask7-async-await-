using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using HometaskEntity.DAL.Contracts;
using HometaskEntity.DAL.Repositories;
using HometaskEntity.DAL.Models;

namespace HometaskEntity.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private AirportContext context;
        public UnitOfWork(AirportContext context)
        {
            this.context = context;
        }

        private AviatorRepository aviatorRepository;
        private CrewRepository crewRepository;
        private DepartureRepository departureRepository;
        private FlightRepository flightRepository;
        private PlaneRepository planeRepository;
        private StewardessRepository stewardessRepository;
        private TicketRepository ticketRepository;
        private TypePlaneRepository typePlaneRepository;

        public IRepository<Aviator> Aviators
        {
            get
            {
                if (aviatorRepository == null)
                    aviatorRepository = new AviatorRepository(context);
                return aviatorRepository;
            }
        }
        public  IRepository<Crew> Crews
        {
            get
            {
                if (crewRepository == null)
                    crewRepository = new CrewRepository(context);
                return crewRepository;
            }
        }
        public IRepository<Departure> Departures
        {
            get
            {
                if (departureRepository == null)
                    departureRepository = new DepartureRepository(context);
                return departureRepository;
            }
        }
        public IRepository<Flight> Flights
        {
            get
            {
                if (flightRepository == null)
                    flightRepository = new FlightRepository(context);
                return flightRepository;
            }
        }
        public IRepository<Plane> Planes
        {
            get
            {
                if (planeRepository == null)
                    planeRepository = new PlaneRepository(context);
                return planeRepository;
            }
        }
        public IRepository<Stewardess> Stewardesses
        {
            get
            {
                if (stewardessRepository == null)
                    stewardessRepository = new StewardessRepository(context);
                return stewardessRepository;
            }
        }
        public IRepository<Ticket> Tickets
        {
            get
            {
                if (ticketRepository == null)
                    ticketRepository = new TicketRepository(context);
                return ticketRepository;
            }
        }
        public IRepository<TypePlane> TypesPlane
        {
            get
            {
                if (typePlaneRepository == null)
                    typePlaneRepository = new TypePlaneRepository(context);
                return typePlaneRepository;
            }
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
