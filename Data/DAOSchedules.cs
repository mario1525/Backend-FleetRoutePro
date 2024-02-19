using Data.dbcontext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Data.Models;
using Entity;

public class DAOSchedules
{
    private readonly fleetRouteProContext _context;

    public DAOSchedules(fleetRouteProContext context)
    {
        _context = context;
    }

    // Obtener todos los horarios
    public async Task<List<ScheduleModels>> GetSchedules()
    {
        return await _context.Schedules.ToListAsync();
    }

    // Obtener un horario por ID
    public async Task<ScheduleModels> GetScheduleById(string Id)
    {
        return await _context.Schedules.FindAsync(Id);
    }

    // Crear un nuevo horario
    public async Task<Mensaje> CreateSchedule(ScheduleModels data)
    {
        Mensaje mensaje = new Mensaje();
        if (data == null)
        {
            mensaje.Status = 400;
            mensaje.mensaje = "No se cargó ningún horario";
            return mensaje;
        }

        _context.Schedules.Add(data);
        await _context.SaveChangesAsync();

        mensaje.Status = 200;
        mensaje.mensaje = "Horario creado correctamente";
        return mensaje;
    }

    // Actualizar un horario existente
    public async Task<Mensaje> UpdateSchedule(ScheduleModels data)
    {
        Mensaje mensaje = new Mensaje();
        if (data == null)
        {
            mensaje.Status = 400;
            mensaje.mensaje = "No se cargó ningún horario";
            return mensaje;
        }

        _context.Entry(data).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        mensaje.Status = 200;
        mensaje.mensaje = "Horario actualizado correctamente";
        return mensaje;
    }

    // Eliminar un horario por ID
    public async Task<Mensaje> DeleteSchedule(string Id)
    {
        Mensaje mensaje = new Mensaje();
        var data = await _context.Schedules.FindAsync(Id);
        if (data == null)
        {
            mensaje.Status = 404;
            mensaje.mensaje = "Horario no encontrado";
            return mensaje;
        }

        _context.Schedules.Remove(data);
        await _context.SaveChangesAsync();

        mensaje.Status = 200;
        mensaje.mensaje = "Horario eliminado correctamente";
        return mensaje;
    }
}
