using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;
using Entity;

namespace Controller
{
    public class RouteControlLogical
    {
        private readonly DAORoutes _daoRoute;

        public RouteControlLogical(DAORoutes daoRoute)
        {
            _daoRoute = daoRoute;
        }

        public async Task<List<RouteModels>> GetRoutes()
        {
            return await _daoRoute.GetRoutes();
        }

        public async Task<RouteModels> GetRouteById(string routeId)
        {
            return await _daoRoute.GetRouteById(routeId);
        }

        public async Task<Mensaje> CreateRoute(RouteModels route)
        {
            try
            {
                // Validar la ruta antes de crearla
                if (route == null)
                {
                    throw new ArgumentNullException(nameof(route));
                }

                // Lógica de validación adicional aquí

                return await _daoRoute.CreateRoute(route);
            }
            catch (Exception ex)
            {
                // Manejar la excepción y devolver un mensaje de error
                return new Mensaje { Status = 500, mensaje = ex.Message };
            }
        }

        public async Task<Mensaje> UpdateRoute(string Id, RouteModels route)
        {
            try
            {
                // Validar la ruta antes de actualizarla
                if (route == null)
                {
                    throw new ArgumentNullException(nameof(route));
                }

                // Lógica de validación adicional aquí

                // Agregar el ID al objeto route
                route.Id = Id;

                return await _daoRoute.UpdateRoute(route);
            }
            catch (Exception ex)
            {
                // Manejar la excepción y devolver un mensaje de error
                return new Mensaje { Status = 500, mensaje = ex.Message };
            }
        }

        public async Task<Mensaje> DeleteRoute(string routeId)
        {
            try
            {
                // Lógica de validación adicional aquí

                return await _daoRoute.DeleteRoute(routeId);
            }
            catch (Exception ex)
            {
                // Manejar la excepción y devolver un mensaje de error
                return new Mensaje { Status = 500, mensaje = ex.Message };
            }
        }
    }
}
