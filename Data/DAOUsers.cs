using Data.dbcontext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Data.Models;
using Entity;

public class DAOUsers
{
    private readonly fleetRouteProContext _context;

    public DAOUsers(fleetRouteProContext context)
    {
        _context = context;
    }

    // Obtener todos los usuarios
    public async Task<List<UsersModels>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }

    // Obtener un usuario por ID
    public async Task<UsersModels> GetUserById(string userId)
    {
        return await _context.Users.FindAsync(userId);
    }   

    // Validar credenciales de usuario
    public async Task<UsersModels> ValidateUserCredential(string username, string password)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.User == username && u.Password == password);
    }

    // Crear un nuevo usuario
    public async Task<Mensaje> CreateUser(UsersModels user)
    {
        Mensaje mensaje = new Mensaje();
        if (user == null)
        {
            mensaje.Status = 400;
            mensaje.mensaje = "No se cargó ningún usuario";
            return mensaje;
        }

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        mensaje.Status = 200;
        mensaje.mensaje = "Usuario creado correctamente";
        return mensaje;
    }

    // Actualizar un usuario existente
    public async Task<Mensaje> UpdateUser(UsersModels user)
    {
        Mensaje mensaje = new Mensaje();
        if (user == null)
        {
            mensaje.Status = 400;
            mensaje.mensaje = "No se cargó ningún usuario";
            return mensaje;
        }

        _context.Entry(user).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        mensaje.Status = 200;
        mensaje.mensaje = "Usuario actualizado correctamente";
        return mensaje;
    }

    // Eliminar un usuario por ID
    public async Task<Mensaje> DeleteUser(string userId)
    {
        Mensaje mensaje = new Mensaje();
        var user = await _context.Users.FindAsync(userId);
        if (user == null)
        {
            mensaje.Status = 404;
            mensaje.mensaje = "Usuario no encontrado";
            return mensaje;
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        mensaje.Status = 200;
        mensaje.mensaje = "Usuario eliminado correctamente";
        return mensaje;
    }
}
