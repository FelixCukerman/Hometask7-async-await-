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
    [Route("api/Crew")]
    public class CrewController : Controller
    {
        private IService<CrewDTO> crewService { get; set; }
        public CrewController(IService<CrewDTO> crewService)
        {
            this.crewService = crewService;
        }

        // GET: api/Crew
        [HttpGet]
        public async Task<List<CrewDTO>> Get()
        {
            return await crewService.GetAll();
        }

        // GET: api/Crew/5
        [HttpGet("{id}")]
        public async Task<CrewDTO> Get(int id)
        {
            var result = await crewService.GetAll();
            return result.FirstOrDefault(x => x.Id == id);
        }

        [HttpGet("getfromapi")]
        public async Task LoadCrew()
        {
            CrewApiService crewApiService = new CrewApiService(crewService);
            await Task.WhenAll(new[] { crewApiService.WriteToLog(), crewApiService.WriteToDB() });
        }

        // POST: api/Crew
        [HttpPost]
        public async Task Post([FromBody]CrewDTO value)
        {
            await crewService.Create(value);
        }
        
        // PUT: api/Crew/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]CrewDTO value)
        {
            await crewService.Update(id, value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await crewService.Delete(id);
        }
    }
}
