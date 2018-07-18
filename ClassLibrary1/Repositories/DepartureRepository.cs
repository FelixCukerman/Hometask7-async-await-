using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using HometaskEntity.DAL.Models;
using HometaskEntity.DAL.Contracts;
using System.Threading.Tasks;

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
            return data.Departures;
        }
        public async Task<Departure> Get(int id)
        {
            return data.Departures.FirstOrDefault(x => x.Id == id);
        }
        public async Task Create(Departure departure)
        {
            await data.Departures.AddAsync(departure);
            await data.SaveChangesAsync();
        }
        public async Task Update(int id, Departure departure)
        {
            var item = data.Departures.FirstOrDefault(x => x.Id == id);
            item = departure;
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
