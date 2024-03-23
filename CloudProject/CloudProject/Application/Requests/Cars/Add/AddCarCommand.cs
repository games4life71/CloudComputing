using MediatR;

namespace Application.Requests.Cars.Add;

public class AddCarCommand:IRequest<(string, bool)>
{

    public string Name { get; set; }

    public int Year { get; set; }

    public int Speed { get; set; }

    public AddCarCommand(string name, int year, int speed)
    {
        Name = name;
        Year = year;
        Speed = speed;
    }


}