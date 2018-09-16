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
    public class StewardessRepository : IRepository<Stewardess>
    {
        private AirportContext data;

        public StewardessRepository(AirportContext data)
        {
            this.data = data;
        }
        public async Task<IEnumerable<Stewardess>> GetAll()
        {
            return await data.Stewardesses.ToListAsync();
        }
        public async Task<Stewardess> Get(int id)
        {
            return await data.Stewardesses.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task Create(Stewardess stewardess)
        {
            await data.Stewardesses.AddAsync(stewardess);
            await data.SaveChangesAsync();
        }
        public async Task Update(int id, Stewardess stewardess)
        {
            var item = data.Stewardesses.FirstOrDefault(x => x.Id == id);
            item = stewardess;
            await data.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            Stewardess stewardess = data.Stewardesses.FirstOrDefault(x => x.Id == id);
            if (stewardess != null)
                data.Stewardesses.Remove(stewardess);
            await data.SaveChangesAsync();
        }
    }
}
