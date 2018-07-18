using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using HometaskEntity.DAL.Models;
using BLL.DTOs;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using HometaskEntity.DAL.Contracts;

namespace BLL.Service
{
    class CrewApiService
    {
        IUnitOfWork unitOfWork;
        public CrewApiService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<List<CrewAPI>> GetCrew()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://5b128555d50a5c0014ef1204.mockapi.io/crew");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                HttpContent responseContent = response.Content;
                var json = await responseContent.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<CrewAPI>>(json);
            }
            else
            {
                throw new Exception("Some trouble is happened!");
            }
        }

        public async Task WriteToLog()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("log_date_time" + DateTime.Now.ToString() + ".csv", FileMode.OpenOrCreate))
            {
                var result = await GetCrew();
                formatter.Serialize(fs, result.Where(x => x.id <= 11));
            }
        }

        public async Task WriteToDB()
        {
            var result = await GetCrew();
            if (result == null)
                throw new System.Exception("Bad request");

            foreach (var item in result)
            {
                Aviator currentAviator = null;
                foreach(var pilot in item.pilot)
                {
                    currentAviator = new Aviator { Id = pilot.Id, Name = pilot.Name, Surname = pilot.Surname, Experience = pilot.Experience, DateOfBirthday = pilot.DateOfBirthday };
                }
                Crew crew = new Crew { Id = item.id, aviator = currentAviator, stewardesses = item.stewardess };
                await unitOfWork.Crews.Create(crew);
            }
        }
    }
}
