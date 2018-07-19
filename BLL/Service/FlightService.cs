using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using HometaskEntity.BLL.DTOs;
using HometaskEntity.DAL.Models;
using HometaskEntity.DAL.Contracts;
using HometaskEntity.BLL.Contracts;
using System.Threading.Tasks;

namespace HometaskEntity.BLL.Service
{
    public class FlightService : IService<FlightDTO>
    {
        IUnitOfWork unitOfWork;
        
        public FlightService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<List<FlightDTO>> GetAll()
        {
            return Mapper.Map<List<FlightDTO>>(await unitOfWork.Flights.GetAll());
        }
        public async Task<FlightDTO> GetById(int id)
        {
            return Mapper.Map<List<FlightDTO>>(await unitOfWork.Flights.GetAll()).FirstOrDefault(x => x.Number == id);
        }
        public async Task Create(FlightDTO flightDTO)
        {
            await unitOfWork.Flights.Create(Mapper.Map<Flight>(flightDTO));
        }
        public async Task Update(int id, FlightDTO flightDTO)
        {
            await unitOfWork.Flights.Update(id, Mapper.Map<Flight>(flightDTO));
        }
        public async Task Delete(int id)
        {
            await unitOfWork.Flights.Delete(id);
        }
    }
}
