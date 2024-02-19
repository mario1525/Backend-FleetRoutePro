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
    [Route("api/Routes")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly RouteControlLogical _routeControlLogical;

        public RouteController(RouteControlLogical routeControlLogical)
        {
            _routeControlLogical = routeControlLogical;
        }

        // GET: api/Routes
        [HttpGet]
        [Authorize]
        public async Task<List<RouteModels>> GetRoutes()
        {
            return await _routeControlLogical.GetRoutes();
        }

        // GET: api/Routes/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<RouteModels> GetRoute(string id)
        {
            return await _routeControlLogical.GetRouteById(id);
        }

        // PUT: api/Routes/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<Mensaje> PutRoute(string id, RouteModels route)
        {
            return await _routeControlLogical.UpdateRoute(id, route);
        }

        // POST: api/Routes
        [HttpPost]
        [Authorize]
        public async Task<Mensaje> PostRoute(RouteModels route)
        {
            return await _routeControlLogical.CreateRoute(route);
        }

        // DELETE: api/Routes/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<Mensaje> DeleteRoute(string id)
        {
            return await _routeControlLogical.DeleteRoute(id);
        }
    }
}
