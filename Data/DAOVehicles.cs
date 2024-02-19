using Data.dbcontext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Data.Models;
using Entity;

public class DAOVehicles
{
    private readonly fleetRouteProContext _context;

    public DAOVehicles(fleetRouteProContext context)
    {
        _context = context;
    }

    // Obtener todos los vehículos
    public async Task<List<VehiclesModels>> GetVehicles()
    {
        return await _context.Vehicles.ToListAsync();
    }

    // Obtener un vehículo por ID
    public async Task<VehiclesModels> GetVehiclesById(string Id)
    {
        return await _context.Vehicles.FindAsync(Id);
    }

    // Crear un nuevo vehículo
    public async Task<Mensaje> CreateVehicle(VehiclesModels data)
    {
        Mensaje mensaje = new Mensaje();
        if (data == null)
        {
            mensaje.Status = 400;
            mensaje.mensaje = "No se cargó ningún vehículo";
            return mensaje;
        }

        _context.Vehicles.Add(data);
        await _context.SaveChangesAsync();

        mensaje.Status = 200;
        mensaje.mensaje = "Vehículo creado correctamente";
        return mensaje;
    }

    // Actualizar un vehículo existente
    public async Task<Mensaje> UpdateVehicle(VehiclesModels data)
    {
        Mensaje mensaje = new Mensaje();
        if (data == null)
        {
            mensaje.Status = 400;
            mensaje.mensaje = "No se cargó ningún vehículo";
            return mensaje;
        }

        _context.Entry(data).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        mensaje.Status = 200;
        mensaje.mensaje = "Vehículo actualizado correctamente";
        return mensaje;
    }

    // Eliminar un vehículo por ID
    public async Task<Mensaje> DeleteVehicle(string Id)
    {
        Mensaje mensaje = new Mensaje();
        var data = await _context.Vehicles.FindAsync(Id);
        if (data == null)
        {
            mensaje.Status = 404;
            mensaje.mensaje = "Vehículo no encontrado";
            return mensaje;
        }

        _context.Vehicles.Remove(data);
        await _context.SaveChangesAsync();

        mensaje.Status = 200;
        mensaje.mensaje = "Vehículo eliminado correctamente";
        return mensaje;
    }
}

