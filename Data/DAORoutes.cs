using Data.dbcontext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Data.Models;
using Entity;

public class DAORoutes
{
    private readonly fleetRouteProContext _context;

    public DAORoutes(fleetRouteProContext context)
    {
        _context = context;
    }

    // Obtener todas las rutas
    public async Task<List<RouteModels>> GetRoutes()
    {
        return await _context.Routes.ToListAsync();
    }

    // Obtener una ruta por ID
    public async Task<RouteModels> GetRouteById(string Id)
    {
        return await _context.Routes.FindAsync(Id);
    }

    // Crear una nueva ruta
    public async Task<Mensaje> CreateRoute(RouteModels data)
    {
        Mensaje mensaje = new Mensaje();
        if (data == null)
        {
            mensaje.Status = 400;
            mensaje.mensaje = "No se cargó ninguna ruta";
            return mensaje;
        }

        _context.Routes.Add(data);
        await _context.SaveChangesAsync();

        mensaje.Status = 200;
        mensaje.mensaje = "Ruta creada correctamente";
        return mensaje;
    }

    // Actualizar una ruta existente
    public async Task<Mensaje> UpdateRoute(RouteModels data)
    {
        Mensaje mensaje = new Mensaje();
        if (data == null)
        {
            mensaje.Status = 400;
            mensaje.mensaje = "No se cargó ninguna ruta";
            return mensaje;
        }

        _context.Entry(data).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        mensaje.Status = 200;
        mensaje.mensaje = "Ruta actualizada correctamente";
        return mensaje;
    }

    // Eliminar una ruta por ID
    public async Task<Mensaje> DeleteRoute(string Id)
    {
        Mensaje mensaje = new Mensaje();
        var data = await _context.Routes.FindAsync(Id);
        if (data == null)
        {
            mensaje.Status = 404;
            mensaje.mensaje = "Ruta no encontrada";
            return mensaje;
        }

        _context.Routes.Remove(data);
        await _context.SaveChangesAsync();

        mensaje.Status = 200;
        mensaje.mensaje = "Ruta eliminada correctamente";
        return mensaje;
    }
}

