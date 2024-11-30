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
			var datas = _classRoomService.GetAll();
			return Ok(datas);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var data = await _classRoomService.GetById(id);

			return Ok(data);
		}

		[HttpPost]
		public IActionResult Create([FromForm] ClassRoomCreateDTO create)
		{
			var data = _classRoomService.Add(create);
			return Ok();
		}

		[HttpPut()]
		public async Task<IActionResult> Update([FromForm] ClassRoomUpdateDTO create)
		{
			await _classRoomService.Update(create);
			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _classRoomService.Delete(id);

			return Ok();
		}
	}
}
