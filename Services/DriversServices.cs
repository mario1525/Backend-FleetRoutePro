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
    [Route("api/Drivers")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly DriversControlLogical _driversContrlollogical;

        public DriversController(DriversControlLogical driversContrlollogical)
        {
            _driversContrlollogical = driversContrlollogical;
        }

        // GET: api/Drivers
        [HttpGet]
        [Authorize]
        public Task<List<DrivesModels>> GetDrivers()
        {
            return _driversContrlollogical.GetDrivers();
        }

        // GET: api/Drivers/{id}
        [HttpGet("{id}")]
        [Authorize]
        public async Task<DrivesModels> GetDriver(string id)
        {
            return await _driversContrlollogical.GetDriverById(id);
        }

        // PUT: api/Drivers/{id}
        [HttpPut("{id}")]
        [Authorize]
        public async Task<Mensaje> PutDriver(string id, DrivesModels driver)
        {
            return await _driversContrlollogical.UpdateDriver(id, driver);
        }

        // POST: api/Drivers
        [HttpPost]
        [Authorize]
        public async Task<Mensaje> PostDriver(DrivesModels driver)
        {
            return await _driversContrlollogical.CreateDriver(driver);
        }

        // DELETE: api/Drivers/{id}
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<Mensaje> DeleteDriver(string id)
        {
            return await _driversContrlollogical.DeleteDriver(id);
        }
    }
}
