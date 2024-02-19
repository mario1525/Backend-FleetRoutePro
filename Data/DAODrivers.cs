using Data.dbcontext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Data.Models;
using Entity;

public class DAODrivers
{
    private readonly fleetRouteProContext _context;

    public DAODrivers(fleetRouteProContext context)
    {
        _context = context;
    }

    // Obtener todos los usuarios
    public async Task<List<DrivesModels>> GetDrivers()
    {
        return await _context.Drivers.ToListAsync();
    }

    // Obtener un Drivers por ID
    public async Task<DrivesModels> GetDriversById(string Id)
    {
        return await _context.Drivers.FindAsync(Id);
    }

    // Crear un nuevo Drivers
    public async Task<Mensaje> CreateDrivers(DrivesModels data)
    {
        Mensaje mensaje = new Mensaje();
        if (data == null)
        {
            mensaje.Status = 400;
            mensaje.mensaje = "No se cargó ningún conductor";
            return mensaje;
        }

        _context.Drivers.Add(data);
        await _context.SaveChangesAsync();

        mensaje.Status = 200;
        mensaje.mensaje = "conductor creado correctamente";
        return mensaje;
    }

    // Actualizar un Drivers existente
    public async Task<Mensaje> UpdateDriver(DrivesModels data)
    {
        Mensaje mensaje = new Mensaje();
        if (data == null)
        {
            mensaje.Status = 400;
            mensaje.mensaje = "No se cargó ningún conductor";
            return mensaje;
        }

        _context.Entry(data).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        mensaje.Status = 200;
        mensaje.mensaje = "conductor actualizado correctamente";
        return mensaje;
    }

    // Eliminar un Drivers por ID
    public async Task<Mensaje> DeleteDriver(string Id)
    {
        Mensaje mensaje = new Mensaje();
        var data = await _context.Drivers.FindAsync(Id);
        if (data == null)
        {
            mensaje.Status = 404;
            mensaje.mensaje = "conductor no encontrado";
            return mensaje;
        }

        _context.Drivers.Remove(data);
        await _context.SaveChangesAsync();

        mensaje.Status = 200;
        mensaje.mensaje = "conductor eliminado correctamente";
        return mensaje;
    }
}

