using Application.Services.CarsAndDriversService;
using MediatR;

namespace Application.Requests.Cars.Update;

public class UpdateCarCommandHandler(CarsAndDriversService carsAndDriversService): IRequestHandler<UpdateCarCommand, (string, bool)>
{

    public async Task<(string, bool)> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
    {
       var result =  await carsAndDriversService.UpdateCar( request.Id, request.Name, request.Year, request.Speed);

       return result;

    }
}