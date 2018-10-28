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
    public class TypePlaneRepository : IRepository<TypePlane>
    {
        private AirportContext data;

        public TypePlaneRepository(AirportContext data)
        {
            this.data = data;
        }
        public async Task<IEnumerable<TypePlane>> GetAll()
        {
            return await data.TypesPlane.ToListAsync();
        }
        public async Task<TypePlane> Get(int id)
        {
            return await data.TypesPlane.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task Create(TypePlane typePlane)
        {
            await data.TypesPlane.AddAsync(typePlane);
            await data.SaveChangesAsync();
        }
        public async Task Update(int id, TypePlane typePlane)
        {
            var item = data.TypesPlane.FirstOrDefault(x => x.Id == id);

            item.ModelOfPlane = typePlane.ModelOfPlane;
            item.CarryingCapacity = typePlane.CarryingCapacity;
            item.CountOfSeats = typePlane.CountOfSeats;

            await data.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            TypePlane typePlane = data.TypesPlane.FirstOrDefault(x => x.Id == id);
            if (typePlane != null)
                data.TypesPlane.Remove(typePlane);
            await data.SaveChangesAsync();
        }
    }
}
