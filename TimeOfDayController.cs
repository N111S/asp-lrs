using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class TimeOfDayController : ControllerBase
{
	private readonly ITimeOfDayService _timeOfDayService;

	public TimeOfDayController(ITimeOfDayService timeOfDayService)
	{
		_timeOfDayService = timeOfDayService;
	}

	[HttpGet]
	public IActionResult GetTimeOfDay()
	{
		var timeOfDay = _timeOfDayService.GetTimeOfDay();
		return Ok(timeOfDay);
	}
}
