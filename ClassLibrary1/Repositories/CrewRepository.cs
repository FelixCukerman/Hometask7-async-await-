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
    public class CrewRepository : IRepository<Crew>
    {
        private AirportContext data;

        public CrewRepository(AirportContext data)
        {
            this.data = data;
        }
        public async Task<IEnumerable<Crew>> GetAll()
        {
            return await data.Crews.ToListAsync();
        }
        public async Task<Crew> Get(int id)
        {
            return await data.Crews.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task Create(Crew crew)
        {
            await data.Crews.AddAsync(crew);
            await data.SaveChangesAsync();
        }
        public async Task Update(int id, Crew crew)
        {
            var item = data.Crews.FirstOrDefault(x => x.Id == id);
            item = crew;
            await data.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            Crew crew = data.Crews.FirstOrDefault(x => x.Id == id);
            if (crew != null)
                data.Crews.Remove(crew);
            await data.SaveChangesAsync();
        }
    }
}
