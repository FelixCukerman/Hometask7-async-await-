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
    public class TicketService : IService<TicketDTO>
    {
        IUnitOfWork unitOfWork;
        public TicketService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<List<TicketDTO>> GetAll()
        {
            return Mapper.Map<List<TicketDTO>>(await unitOfWork.Tickets.GetAll());
        }
        public async Task<TicketDTO> GetById(int id)
        {
            return Mapper.Map<List<TicketDTO>>(await unitOfWork.Tickets.Get(id)).FirstOrDefault();
        }
        public async Task Create(TicketDTO ticketDTO)
        {
            await unitOfWork.Tickets.Create(Mapper.Map<Ticket>(ticketDTO));
        }
        public async Task Update(int id, TicketDTO ticketDTO)
        {
            await unitOfWork.Tickets.Update(id, Mapper.Map<Ticket>(ticketDTO));
        }
        public async Task Delete(int id)
        {
            await unitOfWork.Tickets.Delete(id);
        }
    }
}
