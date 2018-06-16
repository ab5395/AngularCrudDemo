using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatatableApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatatableApp.Controllers
{
    [Produces("application/json")]
    public class EmployeeController : Controller
    {
        EmployeeDataAccessLayer objemployee = new EmployeeDataAccessLayer();

        [HttpGet]
        [Route("api/Employee/Index")]
        public IEnumerable<Employee> Index() => objemployee.GetAllEmployees();

        [HttpPost]
        [Route("api/Employee/Create")]
        public int Create([FromBody] Employee employee) => objemployee.AddEmployee(employee);

        [HttpGet]
        [Route("api/Employee/Details/{id}")]
        public Employee Details(int id) => objemployee.GetEmployeeData(id);

        [HttpPut]
        [Route("api/Employee/Edit")]
        public int Edit([FromBody]Employee employee) => objemployee.UpdateEmployee(employee);

        [HttpDelete]
        [Route("api/Employee/Delete/{id}")]
        public int Delete(int id) => objemployee.DeleteEmployee(id);
    }
}