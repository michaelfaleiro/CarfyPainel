using System.ComponentModel.DataAnnotations;

namespace Api.Dtos.Role
{
    public class CreateRole
    {
        [Required]
        public string Name { get; set; }
    }
}