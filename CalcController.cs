using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]//роутінг
[ApiController]
public class CalcController : ControllerBase
{
	private readonly CalcService _calcService;

	public CalcController(CalcService calcService)
	{
		_calcService = calcService;
	}
	//Мої методи
	[HttpGet("add")]//Запит
	public IActionResult Add(int a, int b)
	{
		return Ok(_calcService.Add(a, b));
	}

	[HttpGet("subtract")]
	public IActionResult Subtract(int a, int b)
	{
		return Ok(_calcService.Subtract(a, b));
	}

}
