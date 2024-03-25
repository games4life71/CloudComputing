using Application.Services.CarInfoService;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CarInfoController(CarInfoService carInfoService):BaseController
{

    [HttpGet]
    public async Task<IActionResult> GetCarInfo(string carMake,string carModel = "")
    {

        var result = await carInfoService.GetCarInfo(carModel,carMake);

        if(!result.Item2)
        {
            return BadRequest("Something went wrong");
        }

        return Ok(result.Item1);

    }




}