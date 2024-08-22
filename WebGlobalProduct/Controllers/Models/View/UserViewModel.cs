using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using WebGlobalProduct.Data.Entities;

namespace WebGlobalProduct.Controllers.Models.View
{
    public class UserViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public RolesEnum Roles { get; set; }


        public UserViewModel() { }

        public UserViewModel(UserEntity user)
        {
            Id = user.Id;
            Name = user.Name;
            LastName = user.LastName;
            Email = user.Email;
            Roles = user.Roles;
         
        }

        public static List<UserViewModel> FromList(List<UserEntity> users)
        {
            var list = new List<UserViewModel>();

            foreach (var user in users)
            {
                list.Add(new UserViewModel(user));
            }

            return list;
        }
    }
}
