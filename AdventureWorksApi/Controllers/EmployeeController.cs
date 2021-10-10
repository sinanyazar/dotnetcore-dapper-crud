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
    }
}