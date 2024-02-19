using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;
using Entity;

namespace Controller
{
    public class SchedulesControlLogical
    {
        private readonly DAOSchedules _daoSchedule;

        public SchedulesControlLogical(DAOSchedules daoSchedule)
        {
            _daoSchedule = daoSchedule;
        }

        public async Task<List<ScheduleModels>> GetSchedules()
        {
            return await _daoSchedule.GetSchedules();
        }

        public async Task<ScheduleModels> GetScheduleById(string scheduleId)
        {
            return await _daoSchedule.GetScheduleById(scheduleId);
        }

        public async Task<Mensaje> CreateSchedule(ScheduleModels schedule)
        {
            try
            {
                // Validar el horario antes de crearlo
                if (schedule == null)
                {
                    throw new ArgumentNullException(nameof(schedule));
                }

                // Lógica de validación adicional aquí

                return await _daoSchedule.CreateSchedule(schedule);
            }
            catch (Exception ex)
            {
                // Manejar la excepción y devolver un mensaje de error
                return new Mensaje { Status = 500, mensaje = ex.Message };
            }
        }

        public async Task<Mensaje> UpdateSchedule(string Id, ScheduleModels schedule)
        {
            try
            {
                // Validar el horario antes de actualizarlo
                if (schedule == null)
                {
                    throw new ArgumentNullException(nameof(schedule));
                }

                // Lógica de validación adicional aquí

                // Agregar el ID al objeto schedule
                schedule.Id = Id;

                return await _daoSchedule.UpdateSchedule(schedule);
            }
            catch (Exception ex)
            {
                // Manejar la excepción y devolver un mensaje de error
                return new Mensaje { Status = 500, mensaje = ex.Message };
            }
        }

        public async Task<Mensaje> DeleteSchedule(string scheduleId)
        {
            try
            {
                // Lógica de validación adicional aquí

                return await _daoSchedule.DeleteSchedule(scheduleId);
            }
            catch (Exception ex)
            {
                // Manejar la excepción y devolver un mensaje de error
                return new Mensaje { Status = 500, mensaje = ex.Message };
            }
        }
    }
}

