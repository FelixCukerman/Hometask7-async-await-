using System;
using AutoMapper;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using HometaskEntity.BLL.DTOs;
using HometaskEntity.DAL.Models;
using HometaskEntity.DAL.Contracts;
using HometaskEntity.BLL.Contracts;
using System.Threading.Tasks;

namespace HometaskEntity.BLL.Service
{
    public class TypePlaneService : IService<TypePlaneDTO>
    {
        IUnitOfWork unitOfWork;
        public TypePlaneService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<List<TypePlaneDTO>> GetAll()
        {
            return Mapper.Map<List<TypePlaneDTO>>(await unitOfWork.TypesPlane.GetAll());
        }
        public async Task<TypePlaneDTO> GetById(int id)
        {
            return Mapper.Map<List<TypePlaneDTO>>(await unitOfWork.TypesPlane.Get(id)).FirstOrDefault();
        }
        public async Task Create(TypePlaneDTO typePlaneDTO)
        {
            await unitOfWork.TypesPlane.Create(Mapper.Map<TypePlane>(typePlaneDTO));
        }
        public async Task Update(int id, TypePlaneDTO typePlaneDTO)
        {
            await unitOfWork.TypesPlane.Update(id, Mapper.Map<TypePlane>(typePlaneDTO));
        }
        public async Task Delete(int id)
        {
            await unitOfWork.TypesPlane.Delete(id);
        }
    }
}
