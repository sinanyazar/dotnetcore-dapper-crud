using BLL.Services;
using DAL.Repositories.HR;
using Entity.Models.HR;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorksApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private DepartmentService _service = new DepartmentService(new DepartmentRepository());

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
        public IActionResult Insert(Department department)
        {
            var result = _service.Insert(department);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Department department)
        {
            var result = _service.Update(department);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(int departmentId)
        {
            var result = _service.Delete(departmentId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}