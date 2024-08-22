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
    public class LibrariesController : Controller
    {
        private readonly ILibraryRepository _repo;

        public LibrariesController(ILibraryRepository repo) 
        {
            _repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces(MediaTypeNames.Application.Json)]
        public ActionResult<List<LibraryViewModel>> GetAll()
        {
            var librariesFromDB = _repo.GetAll();

            var libraries = LibraryViewModel.FromList(librariesFromDB);

            return Ok(libraries);
        }

        [HttpGet("{idLibrary}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public ActionResult<LibraryViewModel> FindById([FromRoute] long idLibrary)
        {
            var libraryFromDB = _repo.FindById(idLibrary);

            if (libraryFromDB == default)
            {
                return NotFound();
            }

            var library = new LibraryViewModel(libraryFromDB);

            return Ok(library);
        }

        [HttpGet("name")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public ActionResult<LibraryViewModel> FindByName([FromQuery] string name)
        {
            var libraryFromDB = _repo.FindByName(name);

            if (libraryFromDB == default)
            {
                return NotFound();
            }

            var library = new LibraryViewModel(libraryFromDB);

            return Ok(library);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes(MediaTypeNames.Application.Json)]

        public async Task<ActionResult> Post([FromBody] LibraryModel createModel)
        {
            var newLibrary = new LibraryEntity(createModel.Name, createModel.TelephoneNumber, createModel.City, createModel.ZipCode, createModel.Address);

            _repo.Add(newLibrary);

            await _repo.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{idLibrary}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> Delete([FromRoute] long idLibrary)
        {
            var library = _repo.FindById(idLibrary);

            if (library == default)
            {
                return NotFound();
            }

            _repo.Remove(library);

            await _repo.SaveChangesAsync();

            return Ok();
        }

    }
}
