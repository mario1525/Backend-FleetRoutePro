using System.Collections.Generic;
using System.Data;
using Data.Models;
using Entity;

namespace Controller
{
    public class UsersContrlollogical
    {
        private readonly DAOUsers _daoUser;

        public UsersContrlollogical(DAOUsers daoUsuario)
        {
            _daoUser = daoUsuario;

        }

        public Task<List<UsersModels>> GetUsers()
        {
            Task<List<UsersModels>> usuarios = _daoUser.GetUsers();
            return usuarios;
        }

        public UsersModels GetUserById(string userId)
        {
            Task<UsersModels> taskDataTable = _daoUser.GetUserById(userId);
            UsersModels usuario = taskDataTable.Result;            
            return usuario;
        }       

        public async Task<UsersModels> CheckPasswordAsync(Login login)
        {
            Task<UsersModels> taskDataTable = _daoUser.ValidateUserCredential(login.User, login.password);
            UsersModels usuario = taskDataTable.Result;
            return usuario;

        }
        
        public async Task<Mensaje> CreateUser(UsersModels user)
        {
            // la lógica para crear un nuevo usuario en el repositorio de datos
            return await _daoUser.CreateUser(user);
        }

        public async Task<Mensaje> UpdateUser(String Id, UsersModels user)
        {
            // agregar el id al objeto user 
            user.ID = Id;
            // lógica para actualizar un usuario en el repositorio de datos
            return await _daoUser.UpdateUser(user);
        }

        public async Task<Mensaje> DeleteUser(string userId)
        {
            // eliminar un usuario del repositorio de datos
            return await _daoUser.DeleteUser(userId);
        }        
    }
}