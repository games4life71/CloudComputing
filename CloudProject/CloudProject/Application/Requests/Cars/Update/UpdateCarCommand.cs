using MediatR;

namespace Application.Requests.Cars.Update;

public class UpdateCarCommand: IRequest<(string,bool)>
{

    public Guid Id { get; set; }

    public string Name { get; set; }

    public int Year { get; set; }

    public int Speed { get; set; }

    public UpdateCarCommand(Guid id , string name, int year, int speed)
    {
        Id = id;
        Name = name;
        Year = year;
        Speed = speed;
    }
}