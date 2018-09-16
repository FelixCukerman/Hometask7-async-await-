using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using HometaskEntity.DAL.Contracts;
using HometaskEntity.DAL.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HometaskEntity.DAL.Repositories
{
    public class PlaneRepository : IRepository<Plane>
    {
        private AirportContext data;
        public PlaneRepository(AirportContext data)
        {
            this.data = data;
        }
        public async Task<IEnumerable<Plane>> GetAll()
        {
            return await data.Planes.ToListAsync();
        }
        public async Task<Plane> Get(int id)
        {
            return await data.Planes.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task Create(Plane plane)
        {
            await data.Planes.AddAsync(plane);
            await data.SaveChangesAsync();
        }
        public async Task Update(int id, Plane plane)
        {
            var item = data.Planes.FirstOrDefault(x => x.Id == id);
            item = plane;
            await data.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            Plane plane = data.Planes.FirstOrDefault(x => x.Id == id);
            if (plane != null)
                data.Planes.Remove(plane);
            await data.SaveChangesAsync();
        }
    }
}
