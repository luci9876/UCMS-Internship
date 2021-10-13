using System.Collections.Generic;


namespace HrApi.Models
{
    public class Company_Employee
    {
        public int id { get; set; }
        public int Company_id { get; set; }
        public int Employee_id { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Company> Companies { get; set; }
    }
}
