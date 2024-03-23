using MediatR;

namespace Application.Requests.Drivers.Add;

public class AddDriverCommand : IRequest<(string, bool)>
{
    public string Name { get; set; }

    public string Team { get; set; }


    public AddDriverCommand(string name, string team)
    {
        Name = name;
        Team = team;
    }
}