using Microsoft.AspNetCore.Mvc;
using SchoolExam.Application.DTOs.ClassRoom;
using SchoolExam.Application.DTOs.Student;
using SchoolExam.Application.Interfaces.Services;
using SchoolExam.Infrastructure.Services;

namespace SchoolExam.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentController : ControllerBase
	{
		private readonly IStudentService _studentService;

		public StudentController(IStudentService studentService)
		{
			_studentService = studentService;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			var datas = _studentService.GetAll();
			return Ok(datas);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var data = await _studentService.GetById(id);

			return Ok(data);
		}

		[HttpPost]
		public IActionResult Create([FromForm] StudentCreateDTO create)
		{
			var data = _studentService.Add(create);

			return Ok();
		}

		[HttpPut()]
		public async Task<IActionResult> Update([FromForm] StudentUpdateDTO update)
		{
			await _studentService.Update(update);
			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _studentService.Delete(id);

			return Ok();
		}
	}
}
