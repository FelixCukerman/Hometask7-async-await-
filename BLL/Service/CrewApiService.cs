using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using HometaskEntity.DAL.Models;
using BLL.DTOs;
using HometaskEntity.BLL.DTOs;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using HometaskEntity.BLL.Contracts;

namespace HometaskEntity.BLL.Service
{
    public class CrewApiService
    {
        IService<CrewDTO> service;
        public CrewApiService(IService<CrewDTO> service)
        {
            this.service = service;
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
            string path = Path.Combine(Environment.CurrentDirectory, @"Logs\", "log_date_time_" + DateTime.Now.ToString("dd-MM-yy___H-mm") + ".csv");

            using (StreamWriter wrt = new StreamWriter(path))
            {
                var crews = await GetCrew();
                await wrt.WriteLineAsync("Crews");
                await wrt.WriteLineAsync(new string('/', 35));
                foreach (var result in crews.Where(x => x.id <= 11))
                {
                    await wrt.WriteLineAsync(result.id.ToString());

                    await wrt.WriteLineAsync("Aviators from crew with id" + result.id + "\n");
                    foreach (var pilot in result.pilot)
                    {
                        await wrt.WriteLineAsync("Id          : " + pilot.Id.ToString());
                        await wrt.WriteLineAsync("Name        : " + pilot.Name);
                        await wrt.WriteLineAsync("Surname     : " + pilot.Surname);
                        await wrt.WriteLineAsync("Experience  : " + pilot.Experience.ToString() + "\n");
                    }

                    await wrt.WriteLineAsync("Stewardesses from crew with id" + result.id + "\n");
                    foreach (var stewardess in result.stewardess)
                    {
                        await wrt.WriteLineAsync("Id          : " + stewardess.Id.ToString());
                        await wrt.WriteLineAsync("Name        :" + stewardess.Name);
                        await wrt.WriteLineAsync("Surname     : " + stewardess.Surname + "\n");
                    }
                    wrt.Flush();
                }
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
                CrewDTO crew = new CrewDTO { Id = item.id, aviator = currentAviator, stewardesses = item.stewardess };
                await service.Create(crew);
            }
        }
    }
}