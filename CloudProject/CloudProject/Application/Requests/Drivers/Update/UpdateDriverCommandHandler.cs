using Application.Services.CarsAndDriversService;
using MediatR;

namespace Application.Requests.Drivers.Update;

public class UpdateDriverCommandHandler(CarsAndDriversService carsAndDriversService)
    : IRequestHandler<UpdateDriverCommand, (string, bool)>
{
    public async Task<(string, bool)> Handle(UpdateDriverCommand request, CancellationToken cancellationToken)
    {
        var result = await carsAndDriversService.UpdateDriver(request.Id, request.Name, request.Team);

        return result;
    }
}