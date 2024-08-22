using System.ComponentModel.DataAnnotations;
using WebGlobalProduct.Data.Entities;

namespace WebGlobalProduct.Controllers.Models.View
{
    public class LibraryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string TelephoneNumber { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
        public string Address { get; set; }

        public LibraryViewModel() { }

        public LibraryViewModel(LibraryEntity library)
        {
            Id = library.Id;
            Name = library.Name;
            TelephoneNumber = library.TelephoneNumber;
            City = library.City;
            ZipCode = library.ZipCode;
            Address = library.Address;
        }

        public static List<LibraryViewModel> FromList(List<LibraryEntity> libraries)
        {
            var list = new List<LibraryViewModel>();

            foreach (var library in libraries)
            {
                list.Add(new LibraryViewModel(library));
            }

            return list;
        }
    }
}
