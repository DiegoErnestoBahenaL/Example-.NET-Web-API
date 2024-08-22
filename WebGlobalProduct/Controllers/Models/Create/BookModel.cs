using System.ComponentModel.DataAnnotations;

namespace WebGlobalProduct.Controllers.Models.CreateUpdate
{
    public class BookModel
    {
        [StringLength(50), Required]
        public string Title { get; set; }

        [StringLength(80), Required]
        public string Description { get; set; }

        [StringLength(50), Required]
        public string Author { get; set; }

        [StringLength(50), Required]
        public string Brand { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public long LibraryId { get; set; }

        public BookModel() { }
    }
}
