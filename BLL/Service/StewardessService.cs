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
    public class StewardessService : IService<StewardessDTO>
    {
        IUnitOfWork unitOfWork;
        public StewardessService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<List<StewardessDTO>> GetAll()
        {
            return Mapper.Map<List<StewardessDTO>>(await unitOfWork.Stewardesses.GetAll());
        }
        public async Task<StewardessDTO> GetById(int id)
        {
            return Mapper.Map<List<StewardessDTO>>(await unitOfWork.Stewardesses.Get(id)).FirstOrDefault();
        }
        public async Task Create(StewardessDTO stewardessDTO)
        {
            await unitOfWork.Stewardesses.Create(Mapper.Map<Stewardess>(stewardessDTO));
        }
        public async Task Update(int id, StewardessDTO stewardessDTO)
        {
            await unitOfWork.Stewardesses.Update(id, Mapper.Map<Stewardess>(stewardessDTO));
        }
        public async Task Delete(int id)
        {
            await unitOfWork.Stewardesses.Delete(id);
        }
    }
}
