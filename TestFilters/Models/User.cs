using System.ComponentModel.DataAnnotations;

namespace TestFilters.Models
{
    public class User
    {
        [Required(ErrorMessage = "ID is Required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; } = string.Empty;
    }
}
