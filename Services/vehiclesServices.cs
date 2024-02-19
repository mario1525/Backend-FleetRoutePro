using Controller;
using Data;
using Data.Models;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    [Route("api/Vehicles")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly VehiclesControlLogical _vehiclesControlLogical;

        public VehiclesController(VehiclesControlLogical vehiclesControlLogical)
        {
            _vehiclesControlLogical = vehiclesControlLogical;
        }

        // GET: api/Vehicles
        [HttpGet]
        [Authorize]
        public async Task<List<VehiclesModels>> GetVehicles()
        {
            return await _vehiclesControlLogical.GetVehicles();
        }

        // GET: api/Vehicles/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<VehiclesModels> GetVehicle(string id)
        {
            return await _vehiclesControlLogical.GetVehicleById(id);
        }

        // PUT: api/Vehicles/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<Mensaje> PutVehicle(string id, VehiclesModels vehicle)
        {
            return await _vehiclesControlLogical.UpdateVehicle(id, vehicle);
        }

        // POST: api/Vehicles
        [HttpPost]
        [Authorize]
        public async Task<Mensaje> PostVehicle(VehiclesModels vehicle)
        {
            return await _vehiclesControlLogical.CreateVehicle(vehicle);
        }

        // DELETE: api/Vehicles/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<Mensaje> DeleteVehicle(string id)
        {
            return await _vehiclesControlLogical.DeleteVehicle(id);
        }
    }
}
