using Application.Services.DriversInfoService;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DriverInfoController(DriverInfoService driverInfoService):BaseController
{

    [HttpGet]
    public async Task<IActionResult> GetDriverInfo(string DriverName)
    {


        var (result, success) = await driverInfoService.GetDriverInfo(DriverName);

        if (!success)
        {
            return BadRequest(result);
        }


        return Ok(result);

    }

}