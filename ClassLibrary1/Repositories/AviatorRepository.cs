﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
            return await data.Aviators.ToListAsync();
        }
        public async Task<Aviator> Get(int id)
        {
            return await data.Aviators.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task Create(Aviator aviator)
        {
            await data.Aviators.AddAsync(aviator);
            await data.SaveChangesAsync();
        }
        public async Task Update(int id, Aviator aviator)
        {
            var item = data.Aviators.FirstOrDefault(x => x.Id == id);
            item.Name = aviator.Name;
            item.Surname = aviator.Surname;
            item.Experience = item.Experience;
            item.DateOfBirthday = item.DateOfBirthday;
            await data.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var aviator = await data.Aviators.FirstOrDefaultAsync(x => x.Id == id);
            if (aviator != null)
                data.Aviators.Remove(aviator);
            await data.SaveChangesAsync();
        }
    }
}