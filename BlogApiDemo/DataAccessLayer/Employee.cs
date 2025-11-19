using System.ComponentModel.DataAnnotations;

namespace BlogApiDemo.DataAccessLayer
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
    }
}
