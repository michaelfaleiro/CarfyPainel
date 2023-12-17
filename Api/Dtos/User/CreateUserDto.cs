using Api.Models;
using System.ComponentModel.DataAnnotations;

namespace Api.Dtos.User
{
    public class CreateUserDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}