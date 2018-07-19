using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using HometaskEntity.DAL.Models;
using HometaskEntity.DAL.Contracts;
using HometaskEntity.BLL.Contracts;
using HometaskEntity.BLL.DTOs;
using System.Timers;


namespace HometaskEntity.BLL
{
    public class FlightHelper
    {
        IService<FlightDTO> service;
        TaskCompletionSource<IEnumerable<FlightDTO>> source;
        Timer timer;
        public FlightHelper(IService<FlightDTO> service)
        {
            this.service = service;
        }
        public async Task<IEnumerable<FlightDTO>> Helper()
        {
            source = new TaskCompletionSource<IEnumerable<FlightDTO>>();
            timer = new Timer(500);
            var flight = await service.GetAll();

            try
            {
                timer.Elapsed += (a, b) =>
                {
                    var result = flight.OrderByDescending(x => x.PointOfDeparture).ThenByDescending(x => x.TimeOfDeparture).Take(5);
                    source.SetResult(result);
                };
            }
            catch (Exception ex)
            {
                source.SetException(ex);
            }

            return await source.Task;
        }
    }
}
