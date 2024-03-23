using Application.Requests.Cars.Add;
using Application.Requests.Cars.Update;
using Application.Services.CarsAndDriversService;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


[ApiController]
[Route("api/v1/[controller]")]
public class CarController: BaseController
{

    private readonly CarsAndDriversService _carsAndDriversService;

    public CarController(CarsAndDriversService carsAndDriversService)
    {
        _carsAndDriversService = carsAndDriversService;
    }


    [HttpGet]
    [Route("cars")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCars()
    {
        var (response, status) = await _carsAndDriversService.GetCars();

        if (!status)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }


    [HttpGet]
    [Route("cars/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCarById(Guid id)
    {

        var (response, status) = await _carsAndDriversService.GetCarById(id);

        if (!status)
        {
            return BadRequest(response);
        }

        return Ok(response);

    }

    [HttpDelete]
    [Route("cars/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteCar(Guid id)
    {
        var (response, status) = await _carsAndDriversService.DeleteCar(id);

        if (!status)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AddCar(AddCarCommand addCarCommand)
    {

        var (respone, status) = await Mediator.Send(addCarCommand);

        if (!status)
        {
            return BadRequest(respone);
        }

        return Ok(respone);


    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateCar(UpdateCarCommand updateCarCommand)
    {
        var (response, status) = await Mediator.Send(updateCarCommand);

        if (!status)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }






}