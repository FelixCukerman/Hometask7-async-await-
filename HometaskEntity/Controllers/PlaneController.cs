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
    [Route("api/Plane")]
    public class PlaneController : Controller
    {
        private IService<PlaneDTO> planeService;
        public PlaneController(IService<PlaneDTO> planeService)
        {
            this.planeService = planeService;
        }
        // GET: api/Plane
        [HttpGet]
        public async Task<List<PlaneDTO>> Get()
        {
            return await planeService.GetAll();
        }

        // GET: api/Plane/5
        [HttpGet("{id}")]
        public async Task<PlaneDTO> Get(int id)
        {
            var result = await planeService.GetAll();
            return result.FirstOrDefault(x => x.Id == id);
        }
        
        // POST: api/Plane
        [HttpPost]
        public async Task Post([FromBody]PlaneDTO value)
        {
            await planeService.Create(value);
        }
        
        // PUT: api/Plane/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]PlaneDTO value)
        {
            await planeService.Update(id, value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await planeService.Delete(id);
        }
    }
}
