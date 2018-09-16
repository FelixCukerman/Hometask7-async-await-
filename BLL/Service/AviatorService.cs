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
    public class AviatorService : IService<AviatorDTO>
    {
        IUnitOfWork unitOfWork;
        public AviatorService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<List<AviatorDTO>> GetAll()
        {
            var aviators = Mapper.Map<List<AviatorDTO>>(await unitOfWork.Aviators.GetAll());
            if (aviators.Count > 0 && aviators != null)
                return aviators;
            else
                throw new System.Exception("Bad request");
        }
        public async Task<AviatorDTO> GetById(int id)
        {
            var item = await unitOfWork.Aviators.Get(id);
            if (item != null)
                return Mapper.Map<List<AviatorDTO>>(item).FirstOrDefault(x => x.Id == id);
            else
                throw new System.Exception("Bad request");
        }
        public async Task Create(AviatorDTO aviatorDTO)
        {
            if (aviatorDTO == null)
                throw new System.Exception("Bad request");
            var aviators = Mapper.Map<List<AviatorDTO>>(await unitOfWork.Aviators.GetAll());
            foreach(var item in aviators)
            {
                if(item.Name == aviatorDTO.Name && item.Surname == aviatorDTO.Surname && item.Experience == aviatorDTO.Experience && item.DateOfBirthday == aviatorDTO.DateOfBirthday)
                {
                    throw new System.Exception("duplication of an object");
                }
            }
            await unitOfWork.Aviators.Create(Mapper.Map<Aviator>(aviatorDTO));
        }
        public async Task Update(int id, AviatorDTO aviatorDTO)
        {
            var item = await unitOfWork.Aviators.Get(id);
            if (aviatorDTO == null || item != null)
                throw new System.Exception("Bad request");
            var aviators = Mapper.Map<List<AviatorDTO>>(await unitOfWork.Aviators.GetAll());
            foreach (var aviator in aviators)
            {
                if (aviator.Name == aviatorDTO.Name && aviator.Surname == aviatorDTO.Surname && aviator.Experience == aviatorDTO.Experience && aviator.DateOfBirthday == aviatorDTO.DateOfBirthday)
                {
                    throw new System.Exception("Duplication of an object");
                }
            }
            await unitOfWork.Aviators.Update(id, Mapper.Map<Aviator>(aviatorDTO));
        }
        public async Task Delete(int id)
        {
            var item = unitOfWork.Aviators.Get(id);
            if (item != null)
                await unitOfWork.Aviators.Delete(id);
        }
    }
}