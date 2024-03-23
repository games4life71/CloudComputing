using Application.Requests.Drivers.Add;
using Application.Requests.Drivers.Update;
using Application.Services.CarsAndDriversService;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class DriverController : BaseController
{
    private readonly CarsAndDriversService _carsAndDriversService;

    public DriverController(CarsAndDriversService carsAndDriversService)
    {
        _carsAndDriversService = carsAndDriversService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDrivers()
    {
        var (response, status) = await _carsAndDriversService.GetDrivers();

        if (!status)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDriverById(Guid id)
    {
        var (response, status) = await _carsAndDriversService.GetDriverById(id);

        if (!status)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteDriver(Guid id)
    {
        var (response, status) = await _carsAndDriversService.DeleteDriver(id);

        if (!status)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AddDriver(AddDriverCommand command)
    {
        var (result,status) = await Mediator.Send(command);
        if (!status)
        {
            return BadRequest(result);
        }

       
        return Ok(result);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateDriver(UpdateDriverCommand command)
    {
        var (result,status) = await Mediator.Send(command);
        if (!status)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}