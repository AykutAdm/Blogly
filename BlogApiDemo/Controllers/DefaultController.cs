using BlogApiDemo.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public IActionResult EmployeeList()
        {
            using var c = new Context();
            var values = c.Employees.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult EmplooyeAdd(Employee employee)
        {
            using var c = new Context();
            c.Add(employee);
            c.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            using var c = new Context();
            var values = c.Employees.Find(id);
            if (values == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(values);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            using var c = new Context();
            var value = c.Employees.Find(id);
            c.Remove(value);
            c.SaveChanges();
            return Ok("Silme İşlemi Başarılı");
        }

        [HttpPut]
        public IActionResult UpdateEmployee(Employee employee)
        {
            using var c = new Context();
            var emp = c.Find<Employee>(employee.EmployeeId);
            if (emp == null)
            {
                return NotFound();
            }
            else
            {
                emp.EmployeeName = employee.EmployeeName;
                c.Update(emp);
                c.SaveChanges();
                return Ok("Güncelleme İşlemi Başarılı");
            }

        }
    }
}
