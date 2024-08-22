using System.ComponentModel.DataAnnotations;

namespace WebGlobalProduct.Controllers.Models.CreateUpdate
{
    public class LibraryModel
    {
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

        public LibraryModel() { }
    }
}
