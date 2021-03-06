﻿using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using HometaskEntity.DAL.Models;

namespace HometaskEntity.DAL.Contracts
{
    public interface IUnitOfWork
    {
        IRepository<Aviator> Aviators { get; }
        IRepository<Crew> Crews { get; }
        IRepository<Departure> Departures { get; }
        IRepository<Flight> Flights { get; }
        IRepository<Plane> Planes { get; }
        IRepository<Stewardess> Stewardesses { get; }
        IRepository<Ticket> Tickets { get; }
        IRepository<TypePlane> TypesPlane { get; }
        void SaveChanges();
    }
}
