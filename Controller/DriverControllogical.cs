using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;
using Entity;

namespace Controller
{
    public class DriversControlLogical
    {
        private readonly DAODrivers _daoDriver;

        public DriversControlLogical(DAODrivers daoDriver)
        {
            _daoDriver = daoDriver;
        }

        public async Task<List<DrivesModels>> GetDrivers()
        {
            return await _daoDriver.GetDrivers();
        }

        public async Task<DrivesModels> GetDriverById(string driverId)
        {
            return await _daoDriver.GetDriversById(driverId);
        }

        public async Task<Mensaje> CreateDriver(DrivesModels driver)
        {
            try
            {
                // Validar el conductor antes de crearlo
                if (driver == null)
                {
                    throw new ArgumentNullException(nameof(driver));
                }

                // Lógica de validación adicional aquí

                return await _daoDriver.CreateDrivers(driver);
            }
            catch (Exception ex)
            {
                // Manejar la excepción y devolver un mensaje de error
                return new Mensaje { Status = 500, mensaje = ex.Message };
            }
        }

        public async Task<Mensaje> UpdateDriver(string Id, DrivesModels driver)
        {
            try
            {
                // Validar el conductor antes de actualizarlo
                if (driver == null)
                {
                    throw new ArgumentNullException(nameof(driver));
                }

                // Lógica de validación adicional aquí

                // Agregar el ID al objeto driver
                driver.ID = Id;

                return await _daoDriver.UpdateDriver(driver);
            }
            catch (Exception ex)
            {
                // Manejar la excepción y devolver un mensaje de error
                return new Mensaje { Status = 500, mensaje = ex.Message };
            }
        }

        public async Task<Mensaje> DeleteDriver(string driverId)
        {
            try
            {
                // Lógica de validación adicional aquí

                return await _daoDriver.DeleteDriver(driverId);
            }
            catch (Exception ex)
            {
                // Manejar la excepción y devolver un mensaje de error
                return new Mensaje { Status = 500, mensaje = ex.Message };
            }
        }
    }
}
