using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;
using WebGlobalProduct.Controllers.Models;
using WebGlobalProduct.Controllers.Models.CreateUpdate;
using WebGlobalProduct.Controllers.Models.View;
using WebGlobalProduct.Data.Entities;
using WebGlobalProduct.Data.Repositories;

namespace WebGlobalProduct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _repo;

        public TaskController(ITaskRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces(MediaTypeNames.Application.Json)]

        public async Task<ActionResult<List<TaskViewModel>>> GetAllAsync(CancellationToken token)
        {
            var books = await _repo.GetAllAsync(token);

            var booksViewList = TaskViewModel.FromList(books);

            return Ok(booksViewList);
        }

        [HttpGet("FromCommonUser/{idUser}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces(MediaTypeNames.Application.Json)]

        public async Task<ActionResult<List<TaskViewModel>>> GetAllForCommonUserAsync([FromRoute] long idUser, CancellationToken token)
        {
            var books = await _repo.GetAllForCommonUserAsync(idUser, token);

            var booksViewList = TaskViewModel.FromList(books);

            return Ok(booksViewList);
        }



        [HttpGet("{idTask}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<TaskViewModel>> FindByIdAsync([FromRoute] long idTask, CancellationToken token)
        {
            var taskFromDB = await _repo.FindByIdAsync(idTask, token);

            if (taskFromDB == default)
            {
                return NotFound();
            }

            var task = new TaskViewModel(taskFromDB);

            return Ok(task);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes(MediaTypeNames.Application.Json)]

        public async Task<ActionResult> Post([FromBody] TaskModel createModel)
        {
            var newTask = new TaskEntity(createModel.Name, createModel.Description, createModel.StartDate, createModel.EndDate, createModel.State, createModel.UserId.Value);

            _repo.Add(newTask);

            await _repo.SaveChangesAsync();

            return Ok(newTask);
        }

        [HttpPut("{idTask}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes(MediaTypeNames.Application.Json)]

        public async Task<ActionResult> Put([FromBody] TaskModel updateModel, [FromRoute] long idTask, CancellationToken token)
        {
            var taskFromDB = await _repo.FindByIdAsync(idTask, token);

            if (taskFromDB == default)
            {
                return NotFound();
            }

            taskFromDB.Name = updateModel.Name;
            taskFromDB.Description = updateModel.Description;
            taskFromDB.StartDate = updateModel.StartDate;
            taskFromDB.EndDate = updateModel.EndDate;
            taskFromDB.State = updateModel.State;

            _repo.Update(taskFromDB);

            await _repo.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{idTask}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> Delete([FromRoute] long idTask, CancellationToken token)
        {
            var task = await _repo.FindByIdAsync(idTask, token);

            if (task == default)
            {
                return NotFound();
            }

            _repo.Remove(task);

            await _repo.SaveChangesAsync();

            return Ok();
        }
    }
}
