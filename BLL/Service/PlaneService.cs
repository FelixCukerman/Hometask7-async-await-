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
    public class PlaneService : IService<PlaneDTO>
    {
        IUnitOfWork unitOfWork;
        public PlaneService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<List<PlaneDTO>> GetAll()
        {
            return Mapper.Map<List<PlaneDTO>>(await unitOfWork.Planes.GetAll());
        }
        public async Task<PlaneDTO> GetById(int id)
        {
            return Mapper.Map<List<PlaneDTO>>(await unitOfWork.Planes.Get(id)).FirstOrDefault();
        }
        public async Task Create(PlaneDTO planeDTO)
        {
            await unitOfWork.Planes.Create(Mapper.Map<Plane>(planeDTO));
        }
        public async Task Update(int id, PlaneDTO planeDTO)
        {
            await unitOfWork.Planes.Update(id, Mapper.Map<Plane>(planeDTO));
        }
        public async Task Delete(int id)
        {
            await unitOfWork.Planes.Delete(id);
        }
    }
}
