using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HometaskEntity.BLL.Contracts;
using HometaskEntity.BLL.Service;
using HometaskEntity.BLL.DTOs;

namespace HometaskEntity.Controllers
{
    [Produces("application/json")]
    [Route("api/Aviators")]
    public class AviatorsController : Controller
    {
        private IService<AviatorDTO> aviatorService { get; set; }
        public AviatorsController(IService<AviatorDTO> aviatorService)
        {
            this.aviatorService = aviatorService;
        }

        // GET: api/Aviators
        [HttpGet]
        public async Task<List<AviatorDTO>> Get()
        {
            var aviators = await aviatorService.GetAll();
            if (aviators.Count != 0 || aviators != null)
                return aviators;
            else
                throw new Exception("Bad request");
        }

        // GET: api/Aviators/5
        [HttpGet("{id}")]
        public async Task<AviatorDTO> Get(int id)
        {
            var result = await aviatorService.GetAll();
            var aviator = result.FirstOrDefault(x => x.Id == id);
            if (aviator != null || id > 0)
                return aviator;
            else
                throw new Exception("Bad request");
        }
        
        // POST: api/Aviators
        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody]AviatorDTO value)
        {
            if (ModelState.IsValid && value != null)
            {
                await aviatorService.Create(value);
                return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }
        }
        
        // PUT: api/Aviators/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]AviatorDTO value)
        {
            await aviatorService.Update(id, value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var result = await aviatorService.GetAll();
            var aviator = result.FirstOrDefault(x => x.Id == id);
            if (aviator != null || id > 0)
                await aviatorService.Delete(id);
            else
                throw new Exception("Bad request");

        }
    }
}