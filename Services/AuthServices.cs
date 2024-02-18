using Controller;
using Data.Models;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace Services
{
    [Route("api/auth")]
    [ApiController]
    public class AuhtController : ControllerBase
    {
        private readonly UsersContrlollogical _UsConLogical;
        private readonly authControllogical _AuthControlLogical;

        public AuhtController(UsersContrlollogical usConLogical, authControllogical authControlLogical)
        {
            _UsConLogical = usConLogical;
            _AuthControlLogical = authControlLogical;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login model)
        {
            UsersModels user = await _UsConLogical.CheckPasswordAsync(model);


            if ( user != null)
            {                               
                 Token token = _AuthControlLogical.GenerateJwtToken(user);
                  return Ok(token);
               
            }

            return Unauthorized("Credenciales inválidas");
        }
    }
}
