using Controller;
using Data;
using Data.Models;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    [Route("api/Schedules")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private readonly SchedulesControlLogical _schedulesContrlollogical;

        public SchedulesController(SchedulesControlLogical schedulesContrlollogical)
        {
            _schedulesContrlollogical = schedulesContrlollogical;
        }

        // GET: api/Schedules
        [HttpGet]
        [Authorize]
        public Task<List<ScheduleModels>> GetSchedules()
        {
            return _schedulesContrlollogical.GetSchedules();
        }

        // GET: api/Schedules/{id}
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ScheduleModels> GetSchedule(string id)
        {
            return await _schedulesContrlollogical.GetScheduleById(id);
        }

        // PUT: api/Schedules/{id}
        [HttpPut("{id}")]
        [Authorize]
        public async Task<Mensaje> PutSchedule(string id, ScheduleModels schedule)
        {
            return await _schedulesContrlollogical.UpdateSchedule(id, schedule);
        }

        // POST: api/Schedules
        [HttpPost]
        [Authorize]
        public async Task<Mensaje> PostSchedule(ScheduleModels schedule)
        {
            return await _schedulesContrlollogical.CreateSchedule(schedule);
        }

        // DELETE: api/Schedules/{id}
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<Mensaje> DeleteSchedule(string id)
        {
            return await _schedulesContrlollogical.DeleteSchedule(id);
        }
    }
}
