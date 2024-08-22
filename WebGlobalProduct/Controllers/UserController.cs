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
    public class UserController : Controller
    {
        private readonly IUserRepository _repo;

        public UserController(IUserRepository repo) 
        {
            _repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<List<UserViewModel>>> GetAll(CancellationToken token)
        {
            var usersFromDB = await _repo.GetAllAsync(token);

            var users = UserViewModel.FromList(usersFromDB);

            return Ok(users);
        }

        [HttpGet("{idUser}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<UserViewModel>> FindByIdAsync ([FromRoute] long idUser, CancellationToken token)
        {
            var userFromDB = await _repo.FindByIdAsync(idUser, token);

            if (userFromDB == default)
            {
                return NotFound();
            }

            var user = new UserViewModel(userFromDB);

            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes(MediaTypeNames.Application.Json)]

        public async Task<ActionResult> Post([FromBody] UserModel createModel)
        {

            var newUser = new UserEntity (createModel.Name, createModel.LastName, createModel.Email, createModel.Password, createModel.Roles);

            _repo.Add(newUser);

            await _repo.SaveChangesAsync();

            return Ok(new UserViewModel(newUser));
        }

        [HttpPut("{idUser}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes(MediaTypeNames.Application.Json)]

        public async Task<ActionResult> Put([FromBody] UserModel updateModel, [FromRoute] long  idUser, CancellationToken token)
        {
            var user = await _repo.FindByIdAsync(idUser, token);

            if (user == default)
            {
                return NotFound();
            }

            user.Name = updateModel.Name;
            user.LastName = updateModel.LastName;
            user.Email = updateModel.Email;
            user.Password = updateModel.Password;
            user.Roles = updateModel.Roles;

            _repo.Update(user);

            await _repo.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{idUser}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> Delete([FromRoute] long idUser, CancellationToken token)
        {
            var user = await _repo.FindByIdAsync(idUser, token);

            if (user == default)
            {
                return NotFound();
            }

            _repo.Remove(user);

            await _repo.SaveChangesAsync();

            return Ok();
        }

    }
}
