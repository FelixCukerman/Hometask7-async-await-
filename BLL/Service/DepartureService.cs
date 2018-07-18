using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using HometaskEntity.BLL.DTOs;
using HometaskEntity.DAL.Models;
using HometaskEntity.DAL.Contracts;
using HometaskEntity.BLL.Contracts;
using System.Threading.Tasks;

namespace HometaskEntity.BLL.Service
{
    public class DepartureService : IService<DepartureDTO>
    {
        IUnitOfWork unitOfWork;
        public DepartureService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<List<DepartureDTO>> GetAll()
        {
            return Mapper.Map<List<DepartureDTO>>(await unitOfWork.Departures.GetAll());
        }
        public async Task<DepartureDTO> GetById(int id)
        {
            return Mapper.Map<List<DepartureDTO>>(await unitOfWork.Departures.GetAll()).FirstOrDefault(x => x.Id == id);
        }
        public async Task Create(DepartureDTO departureDTO)
        {
            await unitOfWork.Departures.Create(Mapper.Map<Departure>(departureDTO));
        }
        public async Task Update(int id, DepartureDTO departureDTO)
        {
            await unitOfWork.Departures.Update(id, Mapper.Map<Departure>(departureDTO));
        }
        public async Task Delete(int id)
        {
            await unitOfWork.Departures.Delete(id);
        }
    }
}
