using Application.Services.JokeService;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class JokeController(JokeService jokeService):BaseController
{

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetRandomJoke()
    {
        var (joke, success) = await jokeService.GetRandomJoke();
        if (!success)
        {
            return BadRequest();
        }

        return Ok(joke);
    }
}