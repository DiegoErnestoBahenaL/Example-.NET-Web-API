using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebGlobalProduct.Data.Entities
{
    public class UserEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [StringLength(80), Required]
        public string Name { get; set; }

        [StringLength(80), Required]
        public string LastName { get; set; }

        [StringLength(100), Required]
        public string Email { get; set; }

        [MaxLength(20), Required]
        public string Password { get; set; }

        [Required]
        public RolesEnum Roles { get; set; }

        public List<TaskEntity> Tasks { get; set; }

        public UserEntity() { }


        public UserEntity(string name, string lastName, string email, string password, RolesEnum roles)
        {
            Name = name;
            LastName = lastName;
            Email = email;
            Password = password;
            Roles = roles;
        }
    }
}
