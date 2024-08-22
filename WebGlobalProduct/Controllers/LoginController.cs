using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using WebGlobalProduct.Controllers.Models;
using WebGlobalProduct.Controllers.Models.CreateUpdate;
using WebGlobalProduct.Controllers.Models.View;
using WebGlobalProduct.Data.Entities;
using WebGlobalProduct.Data.Repositories;

namespace WebGlobalProduct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IUserRepository _repo;

        public LoginController(IUserRepository repo)
        {
            _repo = repo;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Consumes(MediaTypeNames.Application.Json)]

        public async Task<ActionResult> Post([FromBody] LoginModel model, CancellationToken token)
        {

            var user = await _repo.FindAsync(model.Email, model.Password, token);
           
            if (user == default)
            {
                return Unauthorized();
            }

            return Ok(new UserViewModel(user));
        }
    }
}
