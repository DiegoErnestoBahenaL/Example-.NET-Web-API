using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebGlobalProduct.Data.Entities
{
    public class BookEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

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

        [ForeignKey(nameof(LibraryId)), Required]
        public LibraryEntity Library { get; set; }

        public BookEntity() { }

        public BookEntity (string title, string description, string author, string brand, decimal price, long libraryId)
        {
            Title = title;
            Description = description;
            Author = author;
            Brand = brand;
            Price = price;
            LibraryId = libraryId;
        }
    }
}
