using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HometaskEntity.DAL.Contracts;
using HometaskEntity.DAL.Models;

namespace HometaskEntity.DAL.Repositories
{
    public class AviatorRepository : IRepository<Aviator>
    {
        private AirportContext data;
        public AviatorRepository(AirportContext data)
        {
            this.data = data;
        }
        public async Task<IEnumerable<Aviator>> GetAll()
        {
            return data.Aviators;
        }
        public async Task<Aviator> Get(int id)
        {
            return data.Aviators.FirstOrDefault(x => x.Id == id);
        }
        public async Task Create(Aviator aviator)
        {
            await data.Aviators.AddAsync(aviator);
            await data.SaveChangesAsync();
        }
        public async Task Update(int id, Aviator aviator)
        {
            var item = data.Aviators.FirstOrDefault(x => x.Id == id);
            item = aviator;
            await data.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var aviator = data.Aviators.FirstOrDefault(x => x.Id == id);
            if (aviator != null)
                data.Aviators.Remove(aviator);
            await data.SaveChangesAsync();
        }
    }
}