using nelli_lr4;
using Microsoft.AspNetCore.Mvc;


[Route("Library")]
public class LibraryController : Controller
{
	private readonly IConfiguration _configuration;

	public LibraryController(IConfiguration configuration)
	{
		_configuration = configuration;
	}
	[HttpGet("")]
	public IActionResult Index()
	{
		return Content("Hi, reader");
	}

	[HttpGet("Books")]
	public IActionResult GetBooks()
	{
		var books = _configuration.GetSection("Books").Get<List<Book>>();
		return Ok(books);
	}
	[HttpGet("Profile/{id?}")]
	public IActionResult Profile(int? id)
	{
		var userInfo = new UserProfile();
		if (id.HasValue && id >= 0 && id <= 5)
		{
			userInfo = _configuration.GetSection($"Users:{id}").Get<UserProfile>();
			return Ok(userInfo);
		}
		else if (id.HasValue)
		{
			return BadRequest("Wrong id. id should be in range from 0 to 5.");
		}
		else
		{
			return Ok(new UserProfile { Id = -1, Name = "Nelli", Age = 20 });
		}
	}
}