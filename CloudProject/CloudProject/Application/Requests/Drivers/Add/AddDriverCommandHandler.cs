using Application.Services.CarsAndDriversService;
using MediatR;

namespace Application.Requests.Drivers.Add;

public class AddDriverCommandHandler(CarsAndDriversService carsAndDriversService): IRequestHandler<AddDriverCommand, (string, bool)>
{
    public async Task<(string, bool)> Handle(AddDriverCommand request, CancellationToken cancellationToken)
    {
        var result = await carsAndDriversService.AddDriver(request.Name, request.Team);

        return result;
    }
}
