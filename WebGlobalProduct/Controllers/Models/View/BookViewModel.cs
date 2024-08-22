using System.ComponentModel.DataAnnotations;
using WebGlobalProduct.Data.Entities;

namespace WebGlobalProduct.Controllers.Models.View
{
    public class BookViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public long LibraryId { get; set; }


        public BookViewModel() { }

        public BookViewModel(BookEntity book)
        {
            Id = book.Id;
            Title = book.Title;
            Description = book.Description;
            Author = book.Author;
            Brand = book.Brand;
            Price = book.Price;
            LibraryId = book.LibraryId;
        }

        public static List<BookViewModel> FromList(List<BookEntity> books)
        {
            var viewModelList = new List<BookViewModel>();

            foreach (var book in books)
            {
                viewModelList.Add(new BookViewModel(book));
            }

            return viewModelList;
        }
    }
}
