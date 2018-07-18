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
    [Route("api/Flight")]
    public class FlightController : Controller
    {
        private IService<FlightDTO> flightService { get; set; }
        public FlightController(IService<FlightDTO> flightService)
        {
            this.flightService = flightService;
        }
        // GET: api/Flight
        [HttpGet]
        public async Task<List<FlightDTO>> Get()
        {
            return await flightService.GetAll();
        }

        // GET: api/Flight/5
        [HttpGet("{id}")]
        public async Task<FlightDTO> Get(int id)
        {
            var result = await flightService.GetAll();
            return result.FirstOrDefault(x => x.Number == id);
        }
        
        // POST: api/Flight
        [HttpPost]
        public async Task Post([FromBody]FlightDTO value)
        {
            await flightService.Create(value);
        }
        
        // PUT: api/Flight/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]FlightDTO value)
        {
            await flightService.Update(id, value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await flightService.Delete(id);
        }
    }
}
