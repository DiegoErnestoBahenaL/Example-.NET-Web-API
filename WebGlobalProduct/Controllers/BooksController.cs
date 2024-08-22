using Microsoft.AspNetCore.Http;
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
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _repo;

        public BooksController(IBookRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces(MediaTypeNames.Application.Json)]

        public ActionResult<List<BookViewModel>> GetAllFromLibrary()
        {
            var books = _repo.GetAll();

            var booksViewList = BookViewModel.FromList(books);

            return Ok(booksViewList);
        }


        [HttpGet("{idBook}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public ActionResult<BookViewModel> FindById([FromRoute] long idBook)
        {
            var bookFromDB = _repo.FindById(idBook);

            if (bookFromDB == default)
            {
                return NotFound();
            }

            var book = new BookViewModel(bookFromDB);

            return Ok(book);
        }

        [HttpGet("name")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public ActionResult<BookViewModel> FindByName([FromQuery] string name)
        {
            var bookFromDB = _repo.FindByName(name);

            if (bookFromDB == default)
            {
                return NotFound();
            }

            var book = new BookViewModel(bookFromDB);

            return Ok(book);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes(MediaTypeNames.Application.Json)]

        public async Task<ActionResult> Post([FromBody] BookModel createModel)
        {
            var newBook = new BookEntity(createModel.Title, createModel.Description, createModel.Author, createModel.Brand, createModel.Price, createModel.LibraryId);

            _repo.Add(newBook);

            await _repo.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{idBook}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> Delete([FromRoute] long idBook)
        {
            var book = _repo.FindById(idBook);

            if (book == default)
            {
                return NotFound();
            }

            _repo.Remove(book);

            await _repo.SaveChangesAsync();

            return Ok();
        }
    }
}
