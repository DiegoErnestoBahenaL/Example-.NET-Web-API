using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using WebGlobalProduct.Data.Entities;

namespace WebGlobalProduct.Controllers.Models.CreateUpdate
{
    public class UserModel
    {
        [StringLength(80), Required]
        public string Name { get; set; }

        [StringLength(80), Required]
        public string LastName { get; set; }

        [StringLength(100), Required]
        public string Email { get; set; }

        [MaxLength(20), Required]
        public string Password { get; set; }

        [JsonConverter(typeof(StringEnumConverter)), Required]
        public RolesEnum Roles { get; set; }

        public UserModel() { }
    }
}
