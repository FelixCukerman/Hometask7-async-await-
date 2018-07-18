using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using HometaskEntity.DAL.Contracts;
using HometaskEntity.DAL.Models;
using System.Threading.Tasks;

namespace HometaskEntity.DAL.Repositories
{
    public class FlightRepository : IRepository<Flight>
    {
        private AirportContext data;
        public FlightRepository(AirportContext data)
        {
            this.data = data;
        }
        public async Task<IEnumerable<Flight>> GetAll()
        {
            return data.Flights;
        }
        public async Task<Flight> Get(int id)
        {
            return data.Flights.FirstOrDefault(x => x.Number == id);
        }
        public async Task Create(Flight flight)
        {
            await data.Flights.AddAsync(flight);
            await data.SaveChangesAsync();
        }
        public async Task Update(int id, Flight flight)
        {
            var item = data.Flights.FirstOrDefault(x => x.Number == id);
            item = flight;
            await data.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            Flight flight = data.Flights.FirstOrDefault(x => x.Number == id);
            if (flight != null)
                data.Flights.Remove(flight);
            await data.SaveChangesAsync();
        }
    }
}
