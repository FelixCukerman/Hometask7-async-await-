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
    [Route("api/Stewardess")]
    public class StewardessController : Controller
    {
        private IService<StewardessDTO> stewardessService;
        public StewardessController(IService<StewardessDTO> stewardessService)
        {
            this.stewardessService = stewardessService;
        }
        // GET: api/Stewardess
        [HttpGet]
        public async Task<List<StewardessDTO>> Get()
        {
            return await stewardessService.GetAll();
        }

        // GET: api/Stewardess/5
        [HttpGet("{id}")]
        public async Task<StewardessDTO> Get(int id)
        {
            var result = await stewardessService.GetAll();
            return result.FirstOrDefault(x => x.Id == id);
        }
        
        // POST: api/Stewardess
        [HttpPost]
        public async Task Post([FromBody]StewardessDTO value)
        {
            await stewardessService.Create(value);
        }
        
        // PUT: api/Stewardess/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]StewardessDTO value)
        {
            await stewardessService.Update(id, value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await stewardessService.Delete(id);
        }
    }
}
