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
    [Route("api/Departure")]
    public class DepartureController : Controller
    {
        private IService<DepartureDTO> departureService;
        public DepartureController(IService<DepartureDTO> departureService)
        {
            this.departureService = departureService;
        }
        // GET: api/Departure
        [HttpGet]
        public async Task<List<DepartureDTO>> Get()
        {
            return await departureService.GetAll();
        }

        // GET: api/Departure/5
        [HttpGet("{id}")]
        public async Task<DepartureDTO> Get(int id)
        {
            var result = await departureService.GetAll();
            return result.FirstOrDefault(x => x.Id == id);
        }
        
        // POST: api/Departure
        [HttpPost]
        public async Task Post([FromBody]DepartureDTO value)
        {
            await departureService.Create(value);
        }
        
        // PUT: api/Departure/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]DepartureDTO value)
        {
            await departureService.Update(id, value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await departureService.Delete(id);
        }
    }
}
