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
        public IActionResult Get()
        {
            var result = _service.List();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var result = _service.Get(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Insert(Employee employee)
        {
            var result = _service.Insert(employee);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Employee employee)
        {
            var result = _service.Update(employee);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(int employeeId)
        {
            var result = _service.Delete(employeeId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}