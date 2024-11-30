using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolExam.Application.DTOs.ClassRoom;
using SchoolExam.Application.DTOs.Lesson;
using SchoolExam.Application.DTOs.Teacher;
using SchoolExam.Application.Interfaces.Services;
using SchoolExam.Infrastructure.Services;

namespace SchoolExam.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LessonController : ControllerBase
	{

		private readonly ILessonService _lessonService;

		public LessonController(ILessonService lessonService)
		{
			_lessonService = lessonService;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			var datas = _lessonService.GetAll();
			return Ok(datas);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var data = await _lessonService.GetById(id);

			return Ok(data);
		}

		[HttpPost]
		public IActionResult Create([FromForm] LessonCreateDTO create)
		{
			var data = _lessonService.Add(create);

			return Ok();
		}

		[HttpPut()]
		public async Task<IActionResult> Update([FromForm] LessonUpdateDTO update)
		{
			await _lessonService.Update(update);

			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _lessonService.Delete(id);

			return Ok();
		}
	}
}
