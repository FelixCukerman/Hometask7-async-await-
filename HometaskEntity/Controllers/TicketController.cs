using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HometaskEntity.BLL.Service;
using HometaskEntity.BLL.DTOs;
using HometaskEntity.BLL.Contracts;

namespace HometaskEntity.Controllers
{
    [Produces("application/json")]
    [Route("api/Ticket")]
    public class TicketController : Controller
    {
        private IService<TicketDTO> ticketService;
        public TicketController(IService<TicketDTO> ticketService)
        {
            this.ticketService = ticketService;
        }
        // GET: api/Ticket
        [HttpGet]
        public async Task<List<TicketDTO>> Get()
        {
            return await ticketService.GetAll();
        }

        // GET: api/Ticket/5
        [HttpGet("{id}")]
        public async Task<TicketDTO> Get(int id)
        {
            var result = await ticketService.GetAll();
            return result.FirstOrDefault(x => x.Id == id);
        }
        
        // POST: api/Ticket
        [HttpPost]
        public async Task Post([FromBody]TicketDTO value)
        {
            await ticketService.Create(value);
        }
        
        // PUT: api/Ticket/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]TicketDTO value)
        {
            await ticketService.Update(id, value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await ticketService.Delete(id);
        }
    }
}
