using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolExam.Application.DTOs.Exam;
using SchoolExam.Application.DTOs.Student;
using SchoolExam.Application.Interfaces.Services;
using SchoolExam.Infrastructure.Services;

namespace SchoolExam.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ExamController : ControllerBase
	{
		private readonly IExamService _examService;

		public ExamController(IExamService examService)
		{
			_examService = examService;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			var datas = _examService.GetAll();
			return Ok(datas);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var data =  _examService.GetById(id);

			return Ok(data);
		}

		[HttpPost]
		public IActionResult Create([FromForm] ExamCreateDTO create)
		{
			var data = _examService.Add(create);

			return Ok();
		}

		[HttpPut()]
		public async Task<IActionResult> Update([FromForm] ExamUpdateDTO update)
		{
			await _examService.Update(update);
			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _examService.Delete(id);

			return Ok();
		}
	}
}
