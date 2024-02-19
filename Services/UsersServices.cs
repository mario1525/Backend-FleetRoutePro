﻿using Controller;
using Data;
using Data.Models;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Services
{
    [Route("api/Users")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsersContrlollogical _UsConLogical;

        public UsuarioController(UsersContrlollogical usConLogical)
        {
            _UsConLogical = usConLogical;
        }

        // get: api/todoitems
        [HttpGet]
        [Authorize]
        public Task<List<UsersModels>> getusers()
        {
            return _UsConLogical.GetUsers();

        }

        // get: api/todoitems/5
        // <snippet_getbyid>
        [HttpGet("{id}")]
        [Authorize]
        public UsersModels getuser(string id)
        {

            var useritem = _UsConLogical.GetUserById(id);
            return useritem;
        }
        // </snippet_getbyid>

        // put: api/todoitems/5
        // <snippet_update>
        [HttpPut("{id}")]
        [Authorize]
        public async Task<Mensaje> putusuario(string id, UsersModels usuario)
        {
            return await _UsConLogical.UpdateUser(id, usuario);
        }
        // </snippet_update>

        // post: api/todoitems
        // <snippet_create>
        [HttpPost]
        [Authorize]
        public async Task<Mensaje> postuser(UsersModels usuario)
        {
            return await _UsConLogical.CreateUser(usuario);
        }
        // </snippet_create>

        // delete: api/todoitems/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<Mensaje> deleteuser(string id)
        {
            return await _UsConLogical.DeleteUser(id);

        }
    }
}
