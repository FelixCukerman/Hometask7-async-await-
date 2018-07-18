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
    public class CrewService : IService<CrewDTO>
    {
        IUnitOfWork unitOfWork;
        public CrewService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<List<CrewDTO>> GetAll()
        {
            return Mapper.Map<List<CrewDTO>>(await unitOfWork.Crews.GetAll());
        }
        public async Task<CrewDTO> GetById(int id)
        {
            return Mapper.Map<List<CrewDTO>>(await unitOfWork.Aviators.GetAll()).FirstOrDefault(x => x.Id == id);
        }
        public async Task Create(CrewDTO crewDTO)
        {
            await unitOfWork.Crews.Create(Mapper.Map<Crew>(crewDTO));
        }
        public async Task Update(int id, CrewDTO crewDTO)
        {
            await unitOfWork.Crews.Update(id, Mapper.Map<Crew>(crewDTO));
        }
        public async Task Delete(int id)
        {
            await unitOfWork.Crews.Delete(id);
        }
    }
}
