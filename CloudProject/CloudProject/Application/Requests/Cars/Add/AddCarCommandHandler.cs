using Application.Services.CarsAndDriversService;
using MediatR;

namespace Application.Requests.Cars.Add;

public class AddCarCommandHandler(CarsAndDriversService carsAndDriversService):IRequestHandler<AddCarCommand, (string, bool)>
{

    public async Task<(string, bool)> Handle(AddCarCommand request, CancellationToken cancellationToken)
    {

      var result =  await carsAndDriversService.AddCar(request.Name, request.Year, request.Speed);

      return result;

    }
}