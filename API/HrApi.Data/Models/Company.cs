using HrApi.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HrApi.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Founded { get; set; }
        public Image Image { get; set; }
    }
}
