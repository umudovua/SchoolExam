using Microsoft.AspNetCore.Mvc;
using SchoolExam.Application.DTOs.ClassRoom;
using SchoolExam.Application.Interfaces.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolExam.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ClassRoomController : ControllerBase
	{
		private readonly IClassRoomService _classRoomService;

		public ClassRoomController(IClassRoomService classRoomService)
		{
			_classRoomService = classRoomService;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			var data = _classRoomService.GetAll();
			return Ok(data);
		}

		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		[HttpPost]
		public IActionResult Create( ClassRoomCreateDTO create)
		{
			var data = _classRoomService.Add(create);
			return Ok();
		}

		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
