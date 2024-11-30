using Microsoft.AspNetCore.Mvc;
using SchoolExam.Application.DTOs.Teacher;
using SchoolExam.Application.Interfaces.Services;

namespace SchoolExam.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TeacherController : ControllerBase
	{
		private readonly ITeacherService _teacherService;

		public TeacherController(ITeacherService teacherService)
		{
			_teacherService = teacherService;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			var datas = _teacherService.GetAll();
			return Ok(datas);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var data = await _teacherService.GetById(id);

			return Ok(data);
		}

		[HttpPost]
		public IActionResult Create([FromForm] TeacherCreateDTO create)
		{
			var data = _teacherService.Add(create);

			return Ok();
		}

		[HttpPut()]
		public async Task<IActionResult> Update([FromForm] TeacherUpdateDTO update)
		{
			await _teacherService.Update(update);

			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _teacherService.Delete(id);

			return Ok();
		}
	}
}
