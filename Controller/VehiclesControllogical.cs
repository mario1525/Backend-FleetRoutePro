using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;
using Entity;

namespace Controller
{
    public class VehiclesControlLogical
    {
        private readonly DAOVehicles _daoVehicle;

        public VehiclesControlLogical(DAOVehicles daoVehicle)
        {
            _daoVehicle = daoVehicle;
        }

        public async Task<List<VehiclesModels>> GetVehicles()
        {
            return await _daoVehicle.GetVehicles();
        }

        public async Task<VehiclesModels> GetVehicleById(string vehicleId)
        {
            return await _daoVehicle.GetVehiclesById(vehicleId);
        }

        public async Task<Mensaje> CreateVehicle(VehiclesModels vehicle)
        {
            try
            {
                // Validar el vehículo antes de crearlo
                if (vehicle == null)
                {
                    throw new ArgumentNullException(nameof(vehicle));
                }

                // Lógica de validación adicional aquí

                return await _daoVehicle.CreateVehicle(vehicle);
            }
            catch (Exception ex)
            {
                // Manejar la excepción y devolver un mensaje de error
                return new Mensaje { Status = 500, mensaje = ex.Message };
            }
        }

        public async Task<Mensaje> UpdateVehicle(string Id, VehiclesModels vehicle)
        {
            try
            {
                // Validar el vehículo antes de actualizarlo
                if (vehicle == null)
                {
                    throw new ArgumentNullException(nameof(vehicle));
                }

                // Lógica de validación adicional aquí

                // Agregar el ID al objeto vehicle
                vehicle.Id = Id;

                return await _daoVehicle.UpdateVehicle(vehicle);
            }
            catch (Exception ex)
            {
                // Manejar la excepción y devolver un mensaje de error
                return new Mensaje { Status = 500, mensaje = ex.Message };
            }
        }

        public async Task<Mensaje> DeleteVehicle(string vehicleId)
        {
            try
            {
                // Lógica de validación adicional aquí

                return await _daoVehicle.DeleteVehicle(vehicleId);
            }
            catch (Exception ex)
            {
                // Manejar la excepción y devolver un mensaje de error
                return new Mensaje { Status = 500, mensaje = ex.Message };
            }
        }
    }
}
