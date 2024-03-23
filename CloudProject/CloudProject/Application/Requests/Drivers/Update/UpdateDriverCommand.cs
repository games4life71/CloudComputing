using MediatR;

namespace Application.Requests.Drivers.Update;

public class UpdateDriverCommand: IRequest<(string, bool)>
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Team { get; set; }

    public UpdateDriverCommand(Guid id, string name, string team)
    {
        Id = id;
        Name = name;
        Team = team;
    }
}