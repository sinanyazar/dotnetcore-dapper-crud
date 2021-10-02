using System.Collections.Generic;
using BLL.Services;
using Entity.Models.HR;
using Microsoft.AspNetCore.Mvc;
using DAL.Repositories.HR;

namespace AdventureWorksApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private EmployeeService _service = new EmployeeService(new EmployeeRepository());
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _service.List();
        }
    }
}