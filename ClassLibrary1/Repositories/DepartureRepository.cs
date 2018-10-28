using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using HometaskEntity.DAL.Models;
using HometaskEntity.DAL.Contracts;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HometaskEntity.DAL.Repositories
{
    public class DepartureRepository : IRepository<Departure>
    {
        private AirportContext data;

        public DepartureRepository(AirportContext data)
        {
            this.data = data;
        }
        public async Task<IEnumerable<Departure>> GetAll()
        {
            return await data.Departures.ToListAsync();
        }
        public async Task<Departure> Get(int id)
        {
            return await data.Departures.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task Create(Departure departure)
        {
            await data.Departures.AddAsync(departure);
            await data.SaveChangesAsync();
        }
        public async Task Update(int id, Departure departure)
        {
            var item = data.Departures.FirstOrDefault(x => x.Id == id);

            item.FlightObj = departure.FlightObj;
            item.TimeOfDeparture = departure.TimeOfDeparture;

            item.CrewObj.Stewardesses = departure.CrewObj.Stewardesses;

            item.PlaneObj.Name = departure.PlaneObj.Name;
            item.PlaneObj.ReleaseDate = departure.PlaneObj.ReleaseDate;
            item.PlaneObj.TimeSpan = departure.PlaneObj.TimeSpan;
            item.PlaneObj.Type = departure.PlaneObj.Type;

            await data.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            Departure departure = data.Departures.FirstOrDefault(x => x.Id == id);
            if (departure != null)
                data.Departures.Remove(departure);
            await data.SaveChangesAsync();
        }
    }
}
