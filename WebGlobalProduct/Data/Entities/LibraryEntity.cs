using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebGlobalProduct.Data.Entities
{
    public class LibraryEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [StringLength(80), Required]
        public string Name { get; set; }

        [StringLength(10)]
        public string TelephoneNumber { get; set; }

        [StringLength(80), Required]
        public string City { get; set; }

        [Required]
        public int ZipCode { get; set; }

        [StringLength(100), Required]
        public string Address { get; set; }

        public List<BookEntity> Books { get; set; } = new List<BookEntity>();

        public LibraryEntity() { }

        public LibraryEntity (string name, string telephoneNumber, string city, int zipCode, string address)
        { 
            Name = name;
            TelephoneNumber = telephoneNumber;
            City = city;
            ZipCode = zipCode;
            Address = address;
        }
    }
}
