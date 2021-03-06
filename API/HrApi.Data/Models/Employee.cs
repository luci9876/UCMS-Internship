
using HrApi.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace HrApi.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public Image Image { get; set; }
    }
}
