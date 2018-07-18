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
    [Route("api/TypePlane")]
    public class TypePlaneController : Controller
    {
        private IService<TypePlaneDTO> typePlaneService;
        public TypePlaneController(IService<TypePlaneDTO> typePlaneService)
        {
            this.typePlaneService = typePlaneService;
        }
        // GET: api/TypePlane
        [HttpGet]
        public async Task<List<TypePlaneDTO>> Get()
        {
            return await typePlaneService.GetAll();
        }

        // GET: api/TypePlane/5
        [HttpGet("{id}")]
        public async Task<TypePlaneDTO> Get(int id)
        {
            var result = await typePlaneService.GetAll();
            return result.FirstOrDefault(x => x.Id == id);
        }
        
        // POST: api/TypePlane
        [HttpPost]
        public async Task Post([FromBody]TypePlaneDTO value)
        {
            await typePlaneService.Create(value);
        }
        
        // PUT: api/TypePlane/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]TypePlaneDTO value)
        {
            await typePlaneService.Update(id, value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await typePlaneService.Delete(id);
        }
    }
}
